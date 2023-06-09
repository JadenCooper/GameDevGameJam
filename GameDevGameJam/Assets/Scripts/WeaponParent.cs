using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get => pointerInput; set => pointerInput = value; }
    private Vector2 pointerInput;
    public bool IsAttacking { get; private set; }
    public RangedWeapon EquippedWeapon;
    public SpriteRenderer characterRenderer, weaponRenderer;
    public Vector2 facedDirection;
    private float IntialScale;

    public bool PC = true;
    private void Start()
    {
        IntialScale = transform.localScale.y;
    }
    private void Update()
    {
        if (IsAttacking)
        {
            return;
        }

        if (PC)
        {
            // Preprocessing Of Direction For PC
            facedDirection = ((Vector3)PointerPosition - transform.position).normalized;
        }
        else
        {
            facedDirection = PointerPosition;
        }

        transform.right = facedDirection;
        Vector2 scale = transform.localScale;
        if (facedDirection.x < 0)
        {
            scale.y = -IntialScale;
        }
        else if (facedDirection.x > 0)
        {
            scale.y = IntialScale;
        }
        transform.localScale = scale;

        // Makes So Weapons Displays Above Player When Below And Behind When Above
        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }

    public void Attack()
    {
        EquippedWeapon.direction = facedDirection;
        EquippedWeapon.Attack();
    }

    public void Reload()
    {
        EquippedWeapon.Reload();
    }
}
