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
        StartCoroutine(MoanTimer(Random.Range(0.1f, 3f)));
    }

    public void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            knockback.Knock(other.transform.position, other.gameObject);
            other.gameObject.GetComponent<CharacterStats>().TakeDamage(gameObject.GetComponent<CharacterStats>().damage.GetValue());
        }
    }

    IEnumerator MoanTimer(float Timer)
    {
        yield return new WaitForSeconds(Timer);
        audioSource.Play();
    }
}
