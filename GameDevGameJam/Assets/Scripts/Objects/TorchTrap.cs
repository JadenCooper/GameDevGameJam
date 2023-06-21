using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrap : MonoBehaviour
{
    public float Damage = 10f;
    public float TouchDamage = 1f;
    public float TouchDelay = 0.2f;
    private bool canAttack = true;
    private Vector2 ShootDelayRange = new Vector2(1, 8);
    public GameObject Fireball;
    private float damage = 5;
    private float range = 12;
    private float fireBallspeed = 12;
    public List<Transform> ShootPoints = new List<Transform>();
    public AudioSource audioSource;
    private void Start()
    {
        StartCoroutine(FireShot());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CharacterStats stats = collision.gameObject.GetComponent<CharacterStats>();
        if (stats != null && canAttack)
        {
            stats.TakeDamage(TouchDamage);
            canAttack = false;
            StartCoroutine(AttackDelay());
        }
    }

    private IEnumerator FireShot()
    {
        float shootDelay = Random.Range(ShootDelayRange.x, ShootDelayRange.y);
        yield return new WaitForSeconds(shootDelay);
        // Shoot Fire Ball Code Will Go Here
        int FirePoint = Random.Range(0, ShootPoints.Count);
        GameObject newFireBall = Instantiate(Fireball);
        newFireBall.layer = gameObject.layer;
        newFireBall.transform.position = ShootPoints[FirePoint].position;

        Vector3 targ = ShootPoints[FirePoint].transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;

        newFireBall.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Vector2 Firedirection = (ShootPoints[FirePoint].transform.position - transform.position).normalized;

        newFireBall.GetComponent<Bullet>().Initialize(damage, fireBallspeed, range, Firedirection);
        audioSource.Play();
        StartCoroutine(FireShot());
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(TouchDelay);
        canAttack = true;
    }
}
