using UnityEngine;

public interface IInteractable
{
    float HoldDuration { get; }
    bool HoldInteraction { get; }
    bool IsInteractable { get; }

    void OnInteract();
}