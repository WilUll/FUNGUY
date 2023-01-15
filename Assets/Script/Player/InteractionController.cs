using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    [SerializeField] private BaseInteractable currentInteractable;
    public float holdTime;
    public bool interactPressed;

    public void OnInteractPressed()
    {
        interactPressed = true;
    }
    
    public void OnInteractReleased()
    {
        ResetHold();
    }

    private void Update()
    {
        if (interactPressed)
        {
            holdTime += Time.deltaTime;
        }

        if (currentInteractable != null )
        {
            if (currentInteractable.HoldInteraction && holdTime >= currentInteractable.HoldDuration)
            {
                currentInteractable.OnInteract();
                ResetHold();
            }
            else if(!currentInteractable.HoldInteraction && interactPressed)
            {
                currentInteractable.OnInteract();
                ResetHold();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BaseInteractable>())
        {
            Debug.Log("Enter");
            ResetHold();
            currentInteractable = other.GetComponent<BaseInteractable>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == layerMask)
        {
            ResetHold();
            currentInteractable = null;
        }
    }

    private void ResetHold()
    {
        interactPressed = false;
        holdTime = 0;
    }
}
