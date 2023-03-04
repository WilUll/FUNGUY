using System;
using System.Collections;
using System.Collections.Generic;
using IsopodaFramework.Vectors;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float runSpeedMultiplier = 2f;
    
    [SerializeField] private Animator animator;
    
    private CharacterController characterController;
    private Vector2 movementInput;
    private float defaultSpeedMultiplier = 1f;
    private float currentSpeedMultiplier;

    private bool clicked;
    private Ray mousePosition;
    private Vector3 clickedPosition;
    private float stoppingDistance = 0.5f;

    [SerializeField] private Transform pointer;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentSpeedMultiplier = defaultSpeedMultiplier;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        clicked = false;
        movementInput = ctx.ReadValue<Vector2>();
    }
    
    public void MouseMovement(InputAction.CallbackContext ctx)
    {
        mousePosition = Camera.main.ScreenPointToRay(ctx.ReadValue<Vector2>());
    }
    
    public void Click(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (Physics.Raycast(mousePosition, out RaycastHit hit))
            {
                clicked = true; 

                if (hit.collider.GetComponent<Interactable>())
                {
                    StartCoroutine(PickUpItem(hit.collider.GetComponent<Interactable>()));
                }
                Vector3 direction = hit.point - transform.position;
                direction.Normalize();
                pointer.position = hit.point;
                clickedPosition = hit.point;
                movementInput = new Vector2(direction.x, direction.z);
            }
        }
    }

    private IEnumerator PickUpItem(Interactable interactableObject)
    {
        while (clicked)
        {
            Debug.Log("Waiting");
            yield return new WaitForFixedUpdate();
        }

        if (Vector3.Distance(transform.position.XZPlane(), interactableObject.transform.position.XZPlane()) <= 2)
        {
            animator.SetTrigger("Interact");
            yield return new WaitForSeconds(0.415f);
            interactableObject.PickUp();
        }
    }
    
    

    public void Sprint(InputAction.CallbackContext ctx) => currentSpeedMultiplier = ctx.performed ? runSpeedMultiplier : defaultSpeedMultiplier;
    private void FixedUpdate()
    {
        Vector3 velocity = new Vector3(movementInput.x, 0, movementInput.y) * (movementSpeed * currentSpeedMultiplier);

        if (clicked)
        {
            var dist = Vector3.Distance(transform.position.XZPlane(), clickedPosition.XZPlane());
            if (dist < stoppingDistance)
            {
                clicked = false;
                movementInput = Vector2.zero;
            }
        }
        
        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.z);
        
        characterController.Move(velocity * Time.fixedDeltaTime);
    }
}
