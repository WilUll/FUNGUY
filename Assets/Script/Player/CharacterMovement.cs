using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float runSpeedMultiplier = 2f;
    
    private CharacterController characterController;
    private Vector2 movementInput;
    private float defaultSpeedMultiplier = 1f;
    private float currentSpeedMultiplier;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentSpeedMultiplier = defaultSpeedMultiplier;
    }

    public void Move(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    
    public void Sprint(InputAction.CallbackContext ctx) => currentSpeedMultiplier = ctx.performed ? runSpeedMultiplier : defaultSpeedMultiplier;
    private void FixedUpdate()
    {
        Vector3 velocity = new Vector3(movementInput.x, 0, movementInput.y) * (movementSpeed * currentSpeedMultiplier);

        characterController.Move(velocity * Time.fixedDeltaTime);
    }
}
