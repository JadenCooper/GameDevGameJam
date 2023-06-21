using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public KnockBack knockback;

    private AudioSource audioSource;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     audioSource = GetComponent<AudioSource>();
    //     StartCoroutine(MoanTimer(Random.Range(3, 15)));
    // }

    public void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("On collision Zombie script");
            knockback.Knock(other.transform.position, other.gameObject);
        }
    }

    IEnumerator MoanTimer(float Timer)
    {
        yield return new WaitForSeconds(Timer);
        audioSource.Play();
    }
}
