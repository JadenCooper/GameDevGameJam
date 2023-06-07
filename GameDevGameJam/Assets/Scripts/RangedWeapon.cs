 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Transform barrel; // Where Bullet Is Spawned
    public bool isReloading = false;
    public int currentClip;
    public bool IsAttacking { get; set; }
    public bool attackBlock;
    public Vector2 direction;
   // public RangedStats rangedStats;
   // private CharacterStats playerStats;
    public AudioSource audioSource;


    // Temp Weapon Stats To Be Replaced By Stats System When Implemented
    public GameObject bullet;
    public float bulletDamage;
    public float bulletSpeed;
    public float range;
    public float magSize;
    public float fireRate;
    public float reloadSpeed;


    private void Start()
    {
        //playerStats = gameObject.GetComponentInParent<PlayerStats>();
        //currentClip = (int)playerStats.magSize.GetValue();
        currentClip = (int)magSize;
    }

    public void Attack()
    {
        if (attackBlock || isReloading)
        {
            return;
        }
        //animator.SetTrigger("Attack");
        Shoot();
        IsAttacking = true;
        attackBlock = true;
        StartCoroutine(DelayAttack());
    }
    public void Shoot()
    {
        audioSource.Play();
        GameObject newBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        newBullet.transform.position = barrel.position;
        newBullet.transform.rotation = barrel.rotation;
        newBullet.layer = gameObject.layer;
        newBullet.GetComponent<Bullet>().Initialize(bulletDamage, bulletSpeed, range, direction);
        currentClip--;
        if (currentClip <= 0)
        {
            isReloading = true;
            StartCoroutine(Reloading());
        }
    }
    public IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadSpeed);
        isReloading = false;
        currentClip = (int)magSize;
    }

    public IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(fireRate);
        attackBlock = false;
    }
    public void Reload()
    {
        if (isReloading == false)
        {
            Debug.Log("Reload");
            isReloading = true;
            StartCoroutine(Reloading());
        }
    }
}
