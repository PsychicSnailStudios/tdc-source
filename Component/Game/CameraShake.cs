using System.Collections;
using UnityEngine;

/// <summary>
/// Adds a shake function to the camera
/// </summary>
public class CameraShake : MonoBehaviour
{
    #region Fields

    [SerializeField] float duration = 0.15f;
    [SerializeField] float magnitude = 0.2f;

    #endregion

    #region Unity Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // register events
        Events.OnScreenShake.AddListener(StartShaking);
        Events.OnScreenShakeBig.AddListener(StartShakingBig);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Shakes the camera harder
    /// </summary>
    public void StartShakingBig()
    {
        StartCoroutine(Shake(duration, magnitude * 4));
    }

    /// <summary>
    /// Shakes the camera
    /// </summary>
    /// <param name="duration">how long to shake in seconds</param>
    /// <param name="magnitude">how hard to shake</param>
    public void StartShaking()
    {
        StartCoroutine(Shake(duration, magnitude));
    }
    public void StartShaking(int magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }
    public void StartShaking(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    /// <summary>
    /// A coroutine that shakes the camera
    /// </summary>
    /// <param name="duration">how long to shake</param>
    /// <param name="magnitude">how hard to shake</param>
    /// <returns></returns>
    IEnumerator Shake(float duration, float magnitude)
    {
        // save position
        Vector3 origanalPos = transform.position;

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            // get new random direction
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            // move in random direction
            transform.localPosition = new Vector3(x, y, origanalPos.z);

            // increment time
            elapsed += Time.deltaTime;

            yield return null;
        }

        // reset position
        transform.localPosition = new Vector3();
    }

    #endregion
}
