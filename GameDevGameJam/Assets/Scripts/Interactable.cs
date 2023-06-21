using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1.0f;

    public void Awake()
    {
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D>();

        rb.gravityScale = 0;
        collider.radius = radius;
        collider.isTrigger = true;
    }

    public virtual void Interact()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Interact();
        }
    }
}
