using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public KnockBack knockback;

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
}
