using UnityEngine;

/// <summary>
/// The pause menu
/// </summary>
public class PauseMenu : MonoBehaviour
{
	#region Methods

	/// <summary>
	/// Un-pauses the game
	/// </summary>
	public void UnPause()
	{
		Time.timeScale = 1;
		gameObject.SetActive(false);
	}

	#endregion

	#region Unity Methods

	/// <summary>
	/// Called when the gameobject in enabled
	/// </summary>
	private void OnEnable()
	{
		Time.timeScale = 0;
	}

	#endregion
}
