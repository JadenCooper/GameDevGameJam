using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    bool TrapActivated = false;
    bool CanAttack = true;
    float attackDelay = 0.4f;
    public float Damage = 10f;
    public List<GameObject> victims = new List<GameObject>();
    public void ActivateTrap()
    {
        foreach (GameObject victim in victims)
        {
            CharacterStats victimStats = victim.GetComponent<CharacterStats>();
            if (victimStats != null)
            {
                victimStats.TakeDamage(Damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        victims.Add(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        victims.Remove(collision.gameObject);
    }
}
