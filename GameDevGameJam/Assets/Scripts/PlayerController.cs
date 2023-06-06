using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector;
    private Vector2 movement;
    private Rigidbody2D rb2d;
    public float currentSpeed;
    public float Acceleration = 50;
    public float MaxSpeed = 250; // To Be Replaced By The PlayerStats Speed
    private Animator animator;
    public bool isMoving;
    //private PlayerStats playerStats;
    //private RangedWeapon RangedWeapon;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        //playerStats = GetComponent<PlayerStats>();
        //RangedWeapon = GetComponentInChildren<RangedWeapon>();
    }
    private void Start()
    {
        //RangedWeapon.SetStats(playerStats);
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed();
        movementVector *= currentSpeed;
        movement = movementVector;
    }
    private void CalculateSpeed()
    {

        if (MathF.Abs(movementVector.y) == 0 && MathF.Abs(movementVector.x) == 0)
        {
            currentSpeed += -Acceleration * Time.deltaTime;
            isMoving = false;
        }
        else
        {
            currentSpeed += Acceleration * Time.deltaTime;
            isMoving = true;
            CheckSide();
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, MaxSpeed);
    }

    private void CheckSide()
    {
        if (movementVector.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    private void FixedUpdate()
    {
        rb2d.velocity = movement * Time.deltaTime;
        //animator.SetBool("isMoving", isMoving);
        //RangedWeapon.SetStats(playerStats);
    }
}
