using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBack : MonoBehaviour
{
    [SerializeField]
    private float knockBackStrength = 5f, stunDuration = 0.2f;

    // Allows us to add events in the inspector for different objects if needed instead of hardcoding it
    public UnityEvent OnBegin, OnDone;

    public void Knock(Vector3 sendersPosition, GameObject person)
    {
        OnBegin?.Invoke();

        Rigidbody2D rb2d = person.GetComponent<Rigidbody2D>();
        float characterMass = person.GetComponent<CharacterStats>().weight.GetValue();

        knockBackStrength = Mathf.Max(knockBackStrength - characterMass, 4.5f);

        // Calculate the direction of the knockback
        Vector3 direction = (sendersPosition - transform.position).normalized;
        // Apply the knockback
        Vector2 knockbackForce = direction * knockBackStrength;
        rb2d.AddForce(knockbackForce, ForceMode2D.Impulse);
        StartCoroutine(Reset(rb2d));
    }

    // Stop the knockback and reset the velocity
    private IEnumerator Reset(Rigidbody2D person)
    {
        yield return new WaitForSeconds(stunDuration);
        Debug.Log("Reset");
        person.velocity = Vector2.zero;
        OnDone?.Invoke();
    }
}