using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public KnockBack knockback;

    public void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("On collision Zombie script");
            knockback.Knock(other.transform.position);
        }
    }
}
