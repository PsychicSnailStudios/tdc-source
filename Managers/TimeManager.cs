using UnityEngine;

/// <summary>
/// Handles in game time updates
/// </summary>
public class TimeManager : MonoBehaviour
{
	#region Fields

	float lastTime = 0;

	#endregion

	#region Unity Methods

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
    {
		if (lastTime != Global.time)
		{
			Time.timeScale = Global.time;
			lastTime = Global.time;
		}
    }

    #endregion
}
