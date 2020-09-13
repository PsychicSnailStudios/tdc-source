using UnityEngine;

/// <summary>
/// The players health and hitbox
/// </summary>
public class Orb : MonoBehaviour
{
    #region Fields

    [SerializeField] Shield shield;
    float speed;
    float timer;
    int health;
    bool shieldOn = false;

    Rigidbody2D rb;

    #endregion

    #region Properties

    /// <summary>
    /// Whether or not the shield is up
    /// </summary>
    public bool HasShield
    {
        get { return shieldOn; }
    }

    #endregion

    #region Unity Methods

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    void Awake()
    {
        Events.OnShield.AddListener(Shield);

        speed = Global.data.orbSpeed;
        health = Global.data.orbHealth;

        rb = GetComponent<Rigidbody2D>();

        Quaternion rotation = new Quaternion(0, 0, Random.rotation.z, Random.rotation.w);
        transform.rotation = rotation;

        rb.AddForce(transform.up * speed * 20);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
		else
		{
			if (shield.Active)
			{
                shield.Off();
                shieldOn = false;
            }
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Hurts the orb
    /// </summary>
    public void Hit(int amount)
    {
        health -= amount;
        if (health < 1)
        {
            Events.OnGameLost.Invoke();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Shields the orb
    /// </summary>
    void Shield()
    {
        AudioManager.Play(AudioFile.PlayerShield, AudioTrack.SFX);

        shield.SetActive(true);
        shieldOn = true;
        timer = Global.data.shieldDuration;
    }

    #endregion
}
