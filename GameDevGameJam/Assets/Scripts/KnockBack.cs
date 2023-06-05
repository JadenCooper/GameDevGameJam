using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBack : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rb2D;

    [SerializeField]
    private float knockBackStrength = 5f, stunDuration = 0.2f, characterMass = 1f;

    // Allows us to add events in the inspector for different objects if needed instead of hardcoding it
    public UnityEvent OnBegin, OnDone;

    public void Knock(Vector3 sendersPosition) {
        StopAllCoroutines();
        OnBegin?.Invoke();

        // Calculate the direction of the knockback
        Vector3 direction = (transform.position - sendersPosition).normalized;
        // Apply the knockback
        rb2D.AddForce(((characterMass - knockBackStrength) * direction), ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    // Stop the knockback and reset the velocity
    private IEnumerator Reset() {
        yield return new WaitForSeconds(stunDuration);
        rb2D.velocity = Vector2.zero; 
        OnDone?.Invoke();
    }
}
