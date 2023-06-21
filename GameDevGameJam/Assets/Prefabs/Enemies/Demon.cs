using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Demon : EnemyMovement
{
    public float attackDelay = 10.0f;
    public bool isAttacking = false;
    public float AttackRange = 10f;
    public bool CanAttack = false;
    private bool FireLock = false;
    public GameObject FireBall;
    public Transform Mouth;
    public AudioSource FireballSource;
    public AudioSource BarkSource;
    public AudioClip FireBallClip;
    public List<AudioClip> DemonBarks = new List<AudioClip>();

    private void Start()
    {
        base.Start();
        BarkSource.clip = DemonBarks[Random.Range(0, DemonBarks.Count)];
        StartCoroutine(BarkTimer());
    }
    public void Update()
    {
        if (!canSeePlayer)
        {
            if (playerDetector.CheckForPlayer())
            {
                canSeePlayer = true;
                MoveEnemy(gameObject);
            }
        }
        else
        {
            if (Vector2.Distance(gameObject.transform.position, player.transform.position) < AttackRange)
            {
                CanAttack = true;
            }
            else
            {
                CanAttack = false;
            }
        
            if (CanAttack & !FireLock)
            {
                Shoot();
            }
            else
            {
                MoveEnemy(gameObject);
            }
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isAttacking)
        {
            isAttacking = true;
            collision.gameObject.GetComponent<CharacterStats>().TakeDamage(characterStats.damage.GetValue());
            StartCoroutine(HitPlayer(collision.gameObject));
        }
    }

    IEnumerator HitPlayer(GameObject hitTarget)
    {
        speed = 0.0f;
        Debug.Log(hitTarget.transform.name + " was hit by " + gameObject.transform.name);
        // hitTarget.GetComponent<CharacterStats>().takeDamage(gameObject.GetComponent<CharacterStats>().damage);
        KnockBack(hitTarget);
        yield return new WaitForSeconds(attackDelay);
        speed = 1.0f;
        isAttacking = false;
    }

    public void Shoot()
    {
        GameObject newFireBall = Instantiate(FireBall);
        newFireBall.layer = gameObject.layer;
        newFireBall.transform.position = Mouth.position;

        Vector3 targ = player.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;

        newFireBall.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Vector2 Firedirection = (player.transform.position - transform.position).normalized;

        newFireBall.GetComponent<Bullet>().Initialize(characterStats.damage.GetValue(), characterStats.bulletSpeed.GetValue(), characterStats.range.GetValue(), Firedirection);
        FireballSource.clip = FireBallClip;
        FireballSource.Play();
        StartCoroutine(ShootLocker());
    }

    private IEnumerator ShootLocker()
    {
        FireLock = true;
        yield return new WaitForSeconds(characterStats.fireRate.GetValue());
        FireLock = false;
    }
    private IEnumerator BarkTimer()
    {
        BarkSource.Play();
        yield return new WaitForSeconds(Random.Range(4, 15));
        BarkSource.clip = DemonBarks[Random.Range(0, DemonBarks.Count)];
        StartCoroutine(BarkTimer());
    }
}
