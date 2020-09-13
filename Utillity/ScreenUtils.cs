using UnityEngine;

/// <summary>
/// Provides screen utilities
/// </summary>
public static class ScreenUtils
{
    #region Fields

    // cached for efficiency
    static Vector2 screenCenter;

    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;

    static float screenWidth;
    static float screenHight;

    #endregion

    #region Properties

    /// <summary>
    /// Gets center of the screen in world coordinates
    /// </summary>
    /// <value>center of the screen</value>
    public static Vector2 ScreenCenter
    {
        get { return screenCenter; }
    }

    /// <summary>
    /// Gets the left edge of the screen in world coordinates
    /// </summary>
    /// <value>left edge of the screen</value>
    public static float ScreenLeft
    {
        get { return screenLeft; }
    }

    /// <summary>
    /// Gets the right edge of the screen in world coordinates
    /// </summary>
    /// <value>right edge of the screen</value>
    public static float ScreenRight
    {
        get { return screenRight; }
    }

    /// <summary>
    /// Gets the top edge of the screen in world coordinates
    /// </summary>
    /// <value>top edge of the screen</value>
    public static float ScreenTop
    {
        get { return screenTop; }
    }

    /// <summary>
    /// Gets the bottom edge of the screen in world coordinates
    /// </summary>
    /// <value>bottom edge of the screen</value>
    public static float ScreenBottom
    {
        get { return screenBottom; }
    }

    /// <summary>
    /// Gets the width of the screen in world coordinates
    /// </summary>
    /// <value>width of the screen</value>
    public static float ScreenWidth
    {
        get { return screenWidth; }
    }

    /// <summary>
    /// Gets the hight of the screen in world coordinates
    /// </summary>
    /// <value>hight of the screen</value>
    public static float ScreenHight
    {
        get { return screenHight; }
    }

    /// <summary>
    /// Gets the aria of the screen in world coordinates
    /// </summary>
    /// <value>aria of the screen</value>
    public static float ScreenAria
    {
        get { return screenHight * screenWidth; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the screen utilities
    /// </summary>
    public static void Initialize()
    {
        Update();
    }

    /// <summary>
    /// Updates the screen utilities
    /// </summary>
    public static void Update()
    {
        float screenZ = -Camera.main.transform.position.z;

        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);

        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;

        screenWidth = Screen.width;
        screenHight = Screen.height;

        screenCenter = new Vector2((screenRight - screenLeft) / 2, (screenTop - screenBottom) / 2);
    }

    #endregion
}
