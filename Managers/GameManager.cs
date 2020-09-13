using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Handles gameplay
/// </summary>
public class GameManager : MonoBehaviour
{
	#region Fields

	float levelDuration;

	[SerializeField] TMP_Text timer;
	[SerializeField] GameObject gameover;
	[SerializeField] GameObject[] walls;

	#endregion

	#region Unity Methods

	/// <summary>
	/// Called before start
	/// </summary>
	void Awake()
	{
		Global.Initialize();
		ScreenUtils.Initialize();
	}

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
    {
		// set level
		walls[0].transform.position = new Vector3(ScreenUtils.ScreenLeft, 0, 0);
		walls[1].transform.position = new Vector3(ScreenUtils.ScreenRight, 0, 0);
		walls[2].transform.position = new Vector3(0, ScreenUtils.ScreenTop, 0);
		walls[3].transform.position = new Vector3(0, ScreenUtils.ScreenBottom, 0);

		walls[0].transform.localScale = new Vector3(0.01f, ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom, 1);
		walls[1].transform.localScale = new Vector3(0.01f, ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom, 1);
		walls[2].transform.localScale = new Vector3(ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft, 0.01f, 1);
		walls[3].transform.localScale = new Vector3(ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft, 0.01f, 1);

		levelDuration *= Global.data.time;

		Events.OnGameLost.AddListener(End);

		//Cursor.lockState = CursorLockMode.Confined;
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
		if (!Global.over)
		{
			levelDuration += Time.deltaTime;
		}

		timer.text = Math.Round(levelDuration / Global.data.time, 2).ToString();
	}

	#endregion

	#region Methods

	/// <summary>
	/// Ends the game
	/// </summary>
	void End()
	{
		AudioManager.Play(AudioFile.Gameover1, AudioTrack.SFX);
		AudioManager.Play(AudioFile.Gameover2, AudioTrack.SFX);
		gameover.SetActive(true);
		Global.over = true;
	}

	#endregion
}
