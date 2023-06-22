using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public KnockBack knockback;

    private AudioSource audioSource;
    private GameObject player;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MoanTimer(Random.Range(0.1f, 3f)));
        player = GameObject.FindWithTag("Player");
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector2 attackDirection = (other.transform.position - transform.position).normalized;
            Vector2 collisionNormal = other.contacts[0].normal;
            Debug.Log("Help he is hurtin' me");

            // Check if the collision normal is within a certain range of the attack direction
            float dotProduct = Vector2.Dot(attackDirection, collisionNormal);
            knockback.Knock(other.transform.position, other.gameObject);
        }
    }


    public void Attack()
    {
        float damage = gameObject.GetComponent<CharacterStats>().damage.GetValue();
        
        if (player == null)
        {
            Debug.LogError("Can not find player object");
        }

        if(player.GetComponent<CharacterStats>() != null)
        {
            player.GetComponent<CharacterStats>().TakeDamage(damage);
        }

    }

    IEnumerator MoanTimer(float Timer)
    {
        yield return new WaitForSeconds(Timer);
        audioSource.Play();
    }
}