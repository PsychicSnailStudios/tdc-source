using UnityEngine;

/// <summary>
/// A projectile that damages things in the game
/// </summary>
public class Bullet : MonoBehaviour
{
    #region Fields

    int damage = 1;
    int ricochet;
    int ricochetCount;
    float speed;

    Rigidbody2D rb;

    #endregion

    #region Properties

    /// <summary>
    /// The amount of damage this bullet does
    /// </summary>
    public int Damage { get { return damage; } }

    #endregion

    #region Unity Methods

    void OnCollisionEnter2D(Collision2D collision)
    {
		switch (collision.gameObject.tag)
		{
            case Tag.Enemy:
                collision.gameObject.GetComponent<Enemy>().Hit(damage);
                break;

            case Tag.Orb:
                collision.gameObject.GetComponent<Orb>().Hit(damage);
                break;

            case Tag.Bullet:
                if (Global.data.bulletsHaveHealth)
                {
                    Destroy(collision.gameObject);
                }
                break;

            case Tag.Shield:
                Destroy(gameObject);
                break;

            default:
				break;
		}

        if (ricochet >= ricochetCount)
        {
            Instantiate(Resources.Load("Prefabs/Burst"), transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            ricochet++;

            Events.OnScreenShake.Invoke();
        }

        AudioManager.Play(AudioFile.Ricochet, AudioTrack.SFX);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Gives the bullet its starting properties
    /// </summary>
    public void Initialize(int damage, Transform position)
    {
        transform.position = position.position;
        transform.rotation = position.rotation;
        this.damage = damage;

        ricochetCount = Global.data.bulletRicochets;
        speed = Global.data.bulletSpeed;

        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.up * speed * 20);
    }


    #endregion
}
