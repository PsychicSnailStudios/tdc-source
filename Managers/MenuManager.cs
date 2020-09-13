using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Handles menu functionality
/// </summary>
public class MenuManager : MonoBehaviour
{
    #region Fields

    // pause screen
    [SerializeField] GameObject pause;

    #endregion

    #region Unity Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
	{
		if (pause != null && Global.over != true)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
                Pause();
			}
		}
	}

    #region Button Methods

    /// <summary>
    /// Restarts the current level
    /// </summary>
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Returns to the home screen
    /// </summary>
    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Starts the game
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Pauses the game
    /// </summary>
    public void Pause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        pause.SetActive(!pause.activeSelf);
    }

    #endregion

    #endregion
}
