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

    private Rigidbody rb;


    private Vector3 move;
    private void Awake()
    {
        inputActions = new PlayerControls();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        //Movement
        Vector2 movement = GetPlayerMovement();
         move = transform.right * movement.x + transform.forward * movement.y;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = (move * (speed * Time.deltaTime));
    }

    private Vector2 GetPlayerMovement()
    {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }
}
