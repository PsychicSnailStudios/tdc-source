using UnityEngine;

/// <summary>
/// Holds a set of Configuration data for the game
/// </summary>
[CreateAssetMenu(fileName = "Game", menuName = "Game/Config")]
public class GameConfig : ScriptableObject
{
    [Header("Time Configurations")]
    [Space]
    public float time = 1f;

    public float stillTimeScale = 0f;
    public float movmentTimeScale = 0.2f;
    public float shootTimeScale = 1f;

    [Header("Player Configurations")]
    [Space]
    public float playerFireSpeedDuration = 1f;
    public float playerSpeed = 3f;
    public bool reletiveMovment = false;

    public float orbSpeed = 10f;
    public float shieldDuration = 2f;
    public float shieldCoolDown = 4f;
    public int maxShields = 2;
    public int orbHealth = 1;

    public bool bulletsHaveHealth = false;
    public float bulletSpeed = 12f;
    public int bulletRicochets = 6;
    public int basePlayerDamage = 1;

    [Header("Enemy Configurations")]
    [Space]
    public float enemySpeed = 2f;
    public float enemyMinFireRate = 2f;
    public float enemyMaxFireRate = 4f;
    public float minEnemyRange = 4f;
    public float maxEnemyRange = 6f;
    public float enemyFollowRange = 4f;
    public int enemyHealth = 1;
    public int enemyDamage = 1;

    [Header("Spawning Configurations")]
    [Space]
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 2f;
    public float minSpawnDistance = 5f;
}
