using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    // This script handles all player inputs and sends that information out in events
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    public UnityEvent OnAttack, OnReload, OnWeaponSwapInput, onStatsAlter;

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
            GetComponentInChildren<WeaponParent>().PC = false;
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
        Vector2 mousePos = player.FindAction("MousePosition").ReadValue<Vector2>();
        if (PC)
        {
            return Camera.main.ScreenToWorldPoint(mousePos);
        }
        return mousePos;
    }

    private void OnEnable()
    {
        // These Actions/Events Just Say They Occurred
        player.FindAction("Reload").performed += PreformReload;
        player.FindAction("Attack").performed += PerformAttack;
        player.FindAction("Swap Weapon").performed += PreformWeaponSwap;
        player.FindAction("Stats").performed += PreformStatsAlter;
    }


    private void OnDisable()
    {
        player.FindAction("Reload").performed += PreformReload;
        player.FindAction("Attack").performed += PerformAttack;
        player.FindAction("Swap Weapon").performed += PreformWeaponSwap;
        player.FindAction("Stats").performed += PreformStatsAlter;
    }
    private void PreformStatsAlter(InputAction.CallbackContext obj)
    {
        onStatsAlter.Invoke();
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
