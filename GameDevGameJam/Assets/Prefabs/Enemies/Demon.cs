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
    public List<Transform> Mouths = new List<Transform>();
    public AudioSource FireballSource;
    public AudioSource BarkSource;
    public AudioClip FireBallClip;
    public List<AudioClip> DemonBarks = new List<AudioClip>();
    public CharacterStats characterStats;
    public AIData AIData;

    private void Start()
    {
        BarkSource.clip = DemonBarks[Random.Range(0, DemonBarks.Count)];
        StartCoroutine(BarkTimer());
    }

    public void Shoot()
    {
        foreach (Transform mouth in Mouths)
        {
            GameObject newFireBall = Instantiate(FireBall);
            newFireBall.layer = gameObject.layer;
            newFireBall.transform.position = mouth.position;

            Vector3 targ = AIData.targets[0].transform.position;
            targ.z = 0f;

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;

            newFireBall.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            Vector2 Firedirection = (AIData.targets[0].transform.position - transform.position).normalized;

            newFireBall.GetComponent<Bullet>().Initialize(characterStats.damage.GetValue(), characterStats.bulletSpeed.GetValue(), characterStats.range.GetValue(), Firedirection);
            FireballSource.clip = FireBallClip;
            FireballSource.Play();
            StartCoroutine(ShootLocker());
        }
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
