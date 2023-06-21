using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrap : MonoBehaviour
{
    public float Damage = 10f;
    public float TouchDamage = 1f;
    public float TouchDelay = 0.2f;
    private bool canAttack = true;
    private Vector2 ShootDelayRange = new Vector2(2, 12);
    public GameObject Fireball;
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
        StartCoroutine(FireShot());
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(TouchDelay);
        canAttack = true;
    }
}
