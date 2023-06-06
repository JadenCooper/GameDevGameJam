using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 startPostion;
    private float conquaredDistance = 0;
    private Rigidbody2D rb2d;
    public BulletData bulletData;
    public float damage;
    public float MaxDistance;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void Initialize(float newDamage, float Speed, float newMaxDistance, Vector2 direction)
    {
        bulletData.Direction = direction;
        startPostion = transform.position;
        rb2d.velocity = bulletData.Direction * Speed;
        damage = newDamage;
        MaxDistance = newMaxDistance;
    }
    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPostion);
        if (conquaredDistance > MaxDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.layer == gameObject.layer)
        {
            Debug.Log("Ignore");
            Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), hit.GetComponent<Collider2D>());
            return;
        }
        //CharacterStats stats = hit.GetComponent<CharacterStats>();
        //if (stats != null)
        //{
        //    stats.TakeDamage(damage);
        //}
        Destroy(gameObject);
    }
}
