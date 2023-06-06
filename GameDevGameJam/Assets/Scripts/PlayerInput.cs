using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // This script handles all player inputs and sends that information out in events
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    public UnityEvent<float> OnWeaponSwapInput;
    public UnityEvent OnAttack, OnReload;
    [SerializeField]
    private InputActionReference movement, attack, pointerPosition, reload, swapWeapon;
    private void Update()
    {
        // These Actions/Events Give Values
        OnMovementInput?.Invoke(movement.action.ReadValue<Vector2>().normalized);
        OnPointerInput?.Invoke(GetPointerPosition());
    }
    private Vector2 GetPointerPosition()
    {
        Vector2 mousePos = pointerPosition.action.ReadValue<Vector2>();
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnEnable()
    {
        // These Actions/Events Just Say They Occurred
        attack.action.performed += PerformAttack;
        swapWeapon.action.performed += PreformWeaponSwap;
        reload.action.performed += PreformReload;
    }
    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
        swapWeapon.action.performed -= PreformWeaponSwap;
        reload.action.performed -= PreformReload;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        OnAttack?.Invoke();
    }
    private void PreformWeaponSwap(InputAction.CallbackContext obj)
    {
        OnWeaponSwapInput?.Invoke(swapWeapon.action.ReadValue<float>());
    }
    private void PreformReload(InputAction.CallbackContext obj)
    {
        OnReload?.Invoke();
    }
}
