using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Image image;
    [SerializeField] private Color selectedColor, normalColor;

    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        image.color = selectedColor;
    }
    
    public void Deselect()
    {
        image.color = normalColor;
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
