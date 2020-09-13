using UnityEngine;

/// <summary>
/// Controls the player
/// </summary>
public class Player : MonoBehaviour
{
    #region Fields

    float movmentSpeed;
    float timer;
    float boostDuration;
    bool reletiveMovment;

    bool shield = false;

    [SerializeField] Transform gun;

    Vector2 movement;

    InputMaster input;
    Rigidbody2D rb;

    #endregion

    #region Unity Methods

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    void Awake()
    {
        input = new InputMaster();

        input.PlayerMovement.Shield.performed += ctx => UseShield();
        input.PlayerMovement.Shoot.performed += ctx => Shoot();
        input.PlayerMovement.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        input.PlayerMovement.Movement.canceled += ctx => movement = Vector2.zero;

        Events.OnShieldEnd.AddListener(EndShield);
        Events.OnGameLost.AddListener(OnDisable);

        rb = gameObject.GetComponent<Rigidbody2D>();

        movmentSpeed = Global.data.playerSpeed;
        reletiveMovment = Global.data.reletiveMovment;
        boostDuration = Global.data.playerFireSpeedDuration;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        FaceMouse();
        Move();

        if (timer > 0 )
        {
            timer -= Time.deltaTime;
            Global.time = Global.data.shootTimeScale;
        }
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    #endregion

    #region Movement

    /// <summary>
    /// Moves the player
    /// </summary>
    void Move()
	{
        Vector2 moveDir = Vector2.zero;

        if (reletiveMovment)
		{
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - transform.position;

            moveDir = direction.ToVector2();
        }
		else
		{
            moveDir = new Vector2(movement.x, movement.y);
        }

        rb.AddForce(moveDir.normalized * movmentSpeed * Time.deltaTime * 200);

		if (moveDir != Vector2.zero)
		{
            Global.time = Global.data.movmentTimeScale;
		}
		else
		{
            Global.time = Global.data.stillTimeScale;
        }
    }

    /// <summary>
    /// Faces the player in  the direction of the cursor
    /// </summary>
    void FaceMouse()
	{
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        transform.up = direction.ToVector2();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Fires the players weapons
    /// </summary>
    void Shoot()
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/Bullet")) as GameObject;

        go.GetComponent<Bullet>().Initialize(Global.data.basePlayerDamage, gun);

        Events.OnScreenShake.Invoke();

        timer = boostDuration;
        AudioManager.Play(AudioFile.PlayerFire, AudioTrack.SFX);
    }

    /// <summary>
    /// Turns off the shield
    /// </summary>
    void EndShield()
	{
        shield = false;
	}

    /// <summary>
    /// Activates the players shield
    /// </summary>
    void UseShield()
    {
        shield = true;
        Events.OnShield.Invoke();
    }

    #endregion
}
