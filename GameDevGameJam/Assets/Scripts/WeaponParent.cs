using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get => pointerInput; set => pointerInput = value; }
    private Vector2 pointerInput;
    public bool IsAttacking { get; private set; }
    public RangedWeapon EquipedWeapon;
    public SpriteRenderer charcterRenderer, weaponRenderer;
    public Vector2 facedDirection;
    private float IntialScale;
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
        facedDirection = ((Vector3)PointerPosition - transform.position).normalized;
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

        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = charcterRenderer.sortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = charcterRenderer.sortingOrder + 1;
        }
    }

    public void Attack()
    {
        EquipedWeapon.direction = facedDirection;
        EquipedWeapon.Attack();
    }

    public void Reload()
    {
        EquipedWeapon.Reload();
    }
}
