using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    // This script handles all player inputs and sends that information out in events
    public UnityEvent<Vector2> OnMovementInput;
    public UnityEvent<Vector3> OnPointerInput;
    public UnityEvent OnAttack, OnReload, OnWeaponSwapInput;

    private InputActionAsset inputAsset;
    private InputActionMap player;
    private bool PC = true;
    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Play");
        if (GetComponent<PlayerInput>().currentControlScheme != "PC")
        {
            PC = false;
        }
    }
    private void Update()
    {
        // These Actions/Events Give Values
        OnMovementInput?.Invoke(player.FindAction("Movement").ReadValue<Vector2>().normalized);
        OnPointerInput?.Invoke(GetPointerPosition());
    }
    private Vector3 GetPointerPosition()
    {
        Vector3 mousePos = player.FindAction("MousePosition").ReadValue<Vector2>();
        if (PC)
        {
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos = (mousePos - transform.position).normalized;
            return mousePos;
        }
        return mousePos;
    }

    private void OnEnable()
    {
        // These Actions/Events Just Say They Occurred
        player.FindAction("Reload").performed += PreformReload;
        player.FindAction("Attack").performed += PerformAttack;
        player.FindAction("Swap Weapon").performed += PreformWeaponSwap;
    }
    private void OnDisable()
    {
        player.FindAction("Reload").performed += PreformReload;
        player.FindAction("Attack").performed += PerformAttack;
        player.FindAction("Swap Weapon").performed += PreformWeaponSwap;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        OnAttack?.Invoke();
    }
    private void PreformWeaponSwap(InputAction.CallbackContext obj)
    {
        OnWeaponSwapInput?.Invoke();
    }
    private void PreformReload(InputAction.CallbackContext obj)
    {
        OnReload?.Invoke();
    }
}
