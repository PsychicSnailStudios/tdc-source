using UnityEngine.Events;

/// <summary>
/// Handles game events
/// </summary>
public static class Events
{
    #region Gameplay Events

    public static UnityEvent OnGameInitialization = new UnityEvent();

    public static UnityEvent OnGameplayPaused = new UnityEvent();
    public static UnityEvent OnGameplayResumed = new UnityEvent();
    public static UnityEvent OnGameplayQuit = new UnityEvent();

    public static UnityEvent OnGameLost = new UnityEvent();
    public static UnityEvent OnGameWon = new UnityEvent();

    #endregion

    #region Player Events

    public static UnityEvent OnKilledEnemy = new UnityEvent();
    public static UnityEvent OnShield = new UnityEvent();
    public static UnityEvent OnShieldEnd = new UnityEvent();

    #endregion

    #region Juice Events

    public static UnityEvent OnScreenShake = new UnityEvent();
    public static UnityEvent OnScreenShakeBig = new UnityEvent();

    #endregion
}
