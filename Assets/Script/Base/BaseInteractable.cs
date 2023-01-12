using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BaseInteractable : MonoBehaviour, IInteractable
{
    [Header("Interactable Settings")] 
    [SerializeField] private float holdDuration = 1f;
    
    [Space]
    [SerializeField] private bool isInteractable = true;
    
    [SerializeField] private bool holdInteract = false;

    public float HoldDuration
    {
        get => holdDuration;
        set => holdDuration = value;
    }
    
    public bool HoldInteraction => holdInteract;
    public bool IsInteractable => isInteractable;

    public void OnInteract()
    {
        Debug.Log("Interacted");
    }
}
