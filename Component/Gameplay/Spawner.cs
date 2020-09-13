using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns enemies into the game
/// </summary>
public class Spawner : MonoBehaviour
{
    #region Fields

    float minSpawnDistance;
    float minSpawnTime;
    float maxSpawnTime;

    [SerializeField] Transform target;

    [SerializeField] List<Transform> spawnPoints;

    float timer;

    #endregion

    #region Unity Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        minSpawnDistance = Global.data.minSpawnDistance;
        minSpawnTime = Global.data.minSpawnTime;
        maxSpawnTime = Global.data.maxSpawnTime;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
		if (timer > 0)
		{
            timer -= Time.deltaTime;
		}
		else
		{
            if (target != null)
            {
                TrySpawn();
                timer = Random.Range(minSpawnTime, maxSpawnTime);
            }
		}
    }

	#endregion

	#region Spawning

    /// <summary>
    /// Tries to spawn an enemy
    /// </summary>
    void TrySpawn()
	{
        spawnPoints.Shuffle();

        foreach (Transform t in spawnPoints)
        {
            if (Vector3.Distance(t.position, target.position) > minSpawnDistance)
            {
                Spawn(t);
                return;
            }
        }
	}

    /// <summary>
    /// Spawns an enemy
    /// </summary>
    void Spawn(Transform point)
	{
        List<GameObject> objs = new List<GameObject>();

        foreach (GameObject item in Resources.LoadAll("Prefabs/Enemies"))
        {
            objs.Add(item);
        }

        GameObject e = Instantiate(objs[Random.Range(0, objs.Count)]);
        e.GetComponent<Enemy>().Initialize(target, point);
	}

	#endregion
}
