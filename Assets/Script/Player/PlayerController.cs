using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private PlayerControls inputActions;

    private Camera camera;

    private CharacterController characterController;
    private InteractionController interactionController;
    
    private Vector3 move;
    private void Awake()
    {
        inputActions = new PlayerControls();
        characterController = GetComponent<CharacterController>();
        interactionController = GetComponent<InteractionController>();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.Interact.started += OnInteractPressed;
        inputActions.Player.Interact.canceled += OnInteractReleased;
    }

    private void OnInteractReleased(InputAction.CallbackContext obj)
    {
        interactionController.OnInteractReleased();
    }

    private void OnInteractPressed(InputAction.CallbackContext obj)
    {
        interactionController.OnInteractPressed();
    }

    private void OnDisable()
    {
        inputActions.Disable();
        
    }

    private void Update()
    {
        GetInputs();
        GetActions();
    }

    private void GetActions()
    {
        GetRoll();
    }

    private bool GetRoll()
    {
        return inputActions.Player.Roll.triggered;
    }

    private void GetInputs()
    {
        //Movement
        Vector2 movement = GetPlayerMovement();
         move = transform.right * movement.x + transform.forward * movement.y;

         move *= GetPlayerSprint() ? 2f : 1f;


         if (!characterController.isGrounded)
         {
             move.y += -9.82f;
         }
         else
         {
             move.y = 0f;
         }
    }

    private void FixedUpdate()
    {
        Move();
        if (GetRoll()) Roll();
    }

    private void Roll()
    {
        characterController.Move(move * speed * 2f);
    }

    private void Move()
    {
        characterController.Move(move * speed * Time.deltaTime);
    }

    private Vector2 GetPlayerMovement()
    {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }
    
    private bool GetPlayerSprint()
    {
        return inputActions.Player.Sprint.IsPressed();
    }
}
