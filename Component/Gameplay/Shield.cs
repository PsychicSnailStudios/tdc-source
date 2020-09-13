using UnityEngine;

/// <summary>
/// The players shield
/// </summary>
public class Shield : MonoBehaviour
{
    #region Fields

    [SerializeField] Transform home;
    [SerializeField] Animator anim;

	#endregion

	#region Properties

	/// <summary>
	/// Whether or not the shield is active
	/// </summary>
	public bool Active
	{
		get { return gameObject.activeSelf; }
	}

	#endregion

	#region Unity Methods

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
    {
		if (home == null)
		{
            Destroy(gameObject);
		}
		else
		{
            transform.position = home.position;
        }
    }

	#endregion

	#region Methods

	/// <summary>
	/// Toggles the shield
	/// </summary>
	public void SetActive(bool b)
	{
		gameObject.SetActive(b);
	}

	/// <summary>
	/// Turns off the shield
	/// </summary>
	public void Off()
	{
		anim.SetTrigger("Off");
	}

	/// <summary>
	/// Used by the animator to turn off the shield
	/// </summary>
	void End()
	{
		gameObject.SetActive(false);
	}

	#endregion
}
