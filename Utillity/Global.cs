using UnityEngine;

/// <summary>
/// Handles global game data
/// </summary>
public static class Global
{
    public static GameConfig data;

    public static float time;
    public static bool over;

	/// <summary>
	/// Initializes the global data to avoid null references and session carryover
	/// </summary>
	public static void Initialize()
	{
		data = Resources.Load("Data/Game") as GameConfig;

		time = data.time;
		over = false;
	}
}
