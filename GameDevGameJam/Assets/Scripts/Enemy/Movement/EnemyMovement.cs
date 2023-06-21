using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterStats characterStats;

    private Rigidbody2D rb2d;

    [SerializeField]
    private float acceleration = 50, deacceleration = 100;
    [SerializeField]
    private float currentSpeed = 0;
    private Vector2 oldMovementInput;

    public Vector2 MovementInput { get; set; }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        characterStats = GetComponent<CharacterStats>();
    }

    private void FixedUpdate()
    {
        float speed = characterStats.speed.GetValue();
        if (MovementInput.magnitude > 0 && currentSpeed >= 0)
        {
            oldMovementInput = MovementInput;
            currentSpeed += acceleration * speed * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * speed * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, speed);
        rb2d.velocity = oldMovementInput * currentSpeed;
    }
}
