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
            Debug.Log("On collision Zombie script");
            knockback.Knock(other.transform.position);
        }
    }

    IEnumerator MoanTimer(float Timer)
    {
        yield return new WaitForSeconds(Timer);
        audioSource.Play();
    }
}
