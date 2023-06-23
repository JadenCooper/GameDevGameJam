using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private AudioSource audioSource;
    public float attackDistance = 2;
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
        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance <= attackDistance && distance >= -attackDistance)
        {
            if (player == null)
            {
                Debug.Log(gameObject.name + " does not have the character script on it");
                return;
            }

            Vector2 playerPos = player.gameObject.transform.position;
            knockback.Knock(playerPos, player);

            if (player.GetComponent<CharacterStats>() != null)
            {
                player.GetComponent<CharacterStats>().TakeDamage(damage);
            }
        }
    }

    IEnumerator MoanTimer(float Timer)
    {
        yield return new WaitForSeconds(Timer);
        audioSource.Play();
    }
}