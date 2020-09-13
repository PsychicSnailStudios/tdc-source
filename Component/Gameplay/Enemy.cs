using UnityEngine;

/// <summary>
/// A basic enemy in the game
/// </summary>
public class Enemy : MonoBehaviour
{
    #region Fields

    [SerializeField] protected float speed = 1.2f;
    [SerializeField] protected float minFireRate = 0.5f;
    [SerializeField] protected float maxFireRate = 2f;
    [SerializeField] protected int health = 1;

    [SerializeField] protected float minEnemyRange = 4f;
    [SerializeField] protected float maxEnemyRange = 6f;
    [SerializeField] protected float enemyFollowRange = 5f;

    [SerializeField] protected Transform gun;
    [SerializeField] protected ParticleSystem particles;
    [SerializeField] protected Animator anim;

    protected Transform target;
    protected Vector2 direction;
    protected Rigidbody2D rb;

    protected float timer;

    #endregion

    #region Unity Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // used when all enemies are the same
        //minFireRate = Global.data.enemyMinFireRate;
        //maxFireRate = Global.data.enemyMaxFireRate;
        //speed = Global.data.enemySpeed;
        //health = Global.data.enemyHealth;
        //minEnemyRange = Global.data.minEnemyRange;
        //maxEnemyRange = Global.data.maxEnemyRange;
        //enemyFollowRange = Global.data.enemyFollowRange;

        timer = maxFireRate;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
		if (target != null)
		{
            GetDirection();
            FaceTarget();

            float distance = Vector3.Distance(transform.position, target.position);

            if (distance > enemyFollowRange)
            {
                Move(distance);
            }
			else if (enemyFollowRange != 0)
			{
				if (distance < enemyFollowRange / 2)
				{
                    Move(distance, true);
                }
			}

            AI(distance);
        }
    }

    #endregion

    #region Movement

    /// <summary>
    /// Gets the direction to the target
    /// </summary>
    void GetDirection()
	{
        Vector3 newDirection = target.position - transform.position;
        direction = newDirection.ToVector2();
    }

    /// <summary>
    /// Moves the enemy
    /// </summary>
    void Move(float dis, bool reverse = false)
    {
		if (reverse)
		{
            rb.AddForce(-direction.normalized * speed * Time.deltaTime * 100 * dis);
        }
		else
		{
            rb.AddForce(direction.normalized * speed * Time.deltaTime * 100 * dis);
        }
    }

    /// <summary>
    /// Faces the enemy in the direction of its target
    /// </summary>
    void FaceTarget()
    {
        transform.up = direction;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Controls the enemies movement
    /// </summary>
    protected virtual void AI(float distance)
    {
        if (distance < maxEnemyRange && distance > minEnemyRange)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                anim.SetTrigger("Fire");
                particles.Play();
            }
        }
    }

    /// <summary>
    /// Makes the enemy fire a bullet
    /// </summary>
    void Shoot()
    {
        particles.Stop();
        timer = Random.Range(minFireRate, maxFireRate);

        GameObject go = Instantiate(Resources.Load("Prefabs/Bullet"), gun.position, gun.rotation) as GameObject;

        go.GetComponent<Bullet>().Initialize(Global.data.enemyDamage, gun);

        Events.OnScreenShake.Invoke();
        AudioManager.Play(AudioFile.EnemyFire, AudioTrack.SFX);
    }

    /// <summary>
    /// Makes the enemy take damage
    /// </summary>
    /// <param name="amount">the amount of damage to take</param>
    public void Hit(int amount)
    {
        health -= amount;
        if (health < 1)
        {
            Events.OnKilledEnemy.Invoke();
            Instantiate(Resources.Load("Prefabs/Die"), transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Sets up the enemy
    /// </summary>
    public void Initialize(Transform target, Transform position)
	{
        particles.Stop();
        this.target = target;
        transform.position = position.position;
        Awake();
	}

    #endregion
}
