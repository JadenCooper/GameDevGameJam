using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public KnockBack knockback;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MoanTimer(Random.Range(0.1f, 20f)));
    }

    public void Attack()
    {
        if(gameObject.GetComponent<CharacterStats>() == null)
        {
            Debug.Log(gameObject.name + " does not have the character script on it");
        }

        float damage = gameObject.GetComponent<CharacterStats>().damage.GetValue();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.Log(gameObject.name + " does not have the character script on it");
            return;
        }

        Vector2 playerPos = player.gameObject.transform.position;
        knockback.Knock(playerPos, player);

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