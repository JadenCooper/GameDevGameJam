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
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            knockback.Knock(other.transform.position, player);
        }
    }

    public void Attack()
    {
        player.GetComponent<CharacterStats>().TakeDamage(gameObject.GetComponent<CharacterStats>().damage.GetValue());
    }

    IEnumerator MoanTimer(float Timer)
    {
        yield return new WaitForSeconds(Timer);
        audioSource.Play();
    }
}