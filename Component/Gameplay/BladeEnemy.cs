using UnityEngine;

/// <summary>
/// An enemy that gets close and then blows up
/// </summary>
public class BladeEnemy : Enemy
{
    #region Methods

    /// <summary>
    /// Moves the enemy
    /// </summary>
    protected override void AI(float distance)
	{
        if (distance < maxEnemyRange)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Explode();
            }
            anim.SetBool("inRange", true);
            particles.Play();
        }
		else
		{
            anim.SetBool("inRange", false);
            particles.Stop();
        }
    }

    /// <summary>
    /// Makes the enemy explode
    /// </summary>
    void Explode()
	{
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, 2f);

        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].gameObject.tag == Tag.Orb)
            {
                Orb e = targets[i].gameObject.GetComponent<Orb>();

				if (!e.HasShield)
				{
                    e.Hit(5);
				}
            }
        }

        AudioManager.Play(AudioFile.Death, AudioTrack.SFX);
        Instantiate(Resources.Load("Prefabs/Explode"), transform.position, transform.rotation);
        Events.OnScreenShakeBig.Invoke();
        Destroy(gameObject);
    }

    #endregion
}
