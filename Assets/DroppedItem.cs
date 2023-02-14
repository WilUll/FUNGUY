using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DroppedItem : MonoBehaviour, IPickupable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player picked up item");
            Pickup();
        }
    }
    
    [SerializeField] private Item item;
    public void Pickup()
    {
        bool success = InventoryManager.Instance.AddItem(item);
        if (success) Destroy(gameObject);
    }
}
