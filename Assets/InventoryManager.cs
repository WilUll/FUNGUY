using System;
using System.Collections;
using System.Collections.Generic;
using IsopodaFramework.GameSpecifics;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private InventorySlot[] slotsInHotbar;
    [SerializeField] private InventorySlot[] slotsInInventory;

    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private int stackLimit = 10;

    private int selectedSlotIndex = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    public void ScrollHotbar(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            float scrollValue = ctx.ReadValue<float>();
            if (scrollValue > 0)
            {
                if (selectedSlotIndex < slotsInHotbar.Length - 1)
                    ChangeSelectedSlot(selectedSlotIndex + 1);
                else
                    ChangeSelectedSlot(0);
            }
            else
            {
                if (selectedSlotIndex > 0)
                    ChangeSelectedSlot(selectedSlotIndex - 1);
                else
                    ChangeSelectedSlot(slotsInHotbar.Length - 1);
            }
        }
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlotIndex >= 0)
            slotsInHotbar[selectedSlotIndex].Deselect();

        slotsInHotbar[newValue].Select();
        selectedSlotIndex = newValue;
    }

    public bool AddItem(Item item)
    {
        return ItemIsInInventory(item) || TryToAddItemToInventory(item);
    }

    private void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }
    
    public Item GetSelectedItem(bool useItem = false)
    {
        InventoryItem item = slotsInHotbar[selectedSlotIndex].GetComponentInChildren<InventoryItem>();
        if (item == null) return null;

        if (useItem)
        {
            item.itemAmount--;
            if (item.itemAmount <= 0)
                Destroy(item.gameObject);
            else
                item.RefreshAmount();
        }

        return item.item;
    }

    private bool TryToAddItemToInventory(Item item)
    {
        foreach (var slot in slotsInHotbar)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        foreach (var slot in slotsInInventory)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }
    
    private bool TryToRemoveItemFromInventory(Item item)
    {
        foreach (var slot in slotsInInventory)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot.item == item)
            {
                itemInSlot.itemAmount--;
                itemInSlot.RefreshAmount();
                return true;
            }
        }
        
        foreach (var slot in slotsInHotbar)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot.item == item)
            {
                itemInSlot.itemAmount--;
                itemInSlot.RefreshAmount();
                return true;
            }
        }
        
        return false;
    }

    private bool ItemIsInInventory(Item item)
    {
        if (!item.stackable) return false;

        foreach (var slot in slotsInHotbar)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.itemAmount < stackLimit)
            {
                itemInSlot.itemAmount++;
                itemInSlot.RefreshAmount();
                return true;
            }
        }

        foreach (var slot in slotsInInventory)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.itemAmount < stackLimit)
            {
                itemInSlot.itemAmount++;
                itemInSlot.RefreshAmount();
                return true;
            }
        }

        return false;
    }

    public int TimesItemIsInInventory(Item item)
    {
        int itemCount = 0;
        foreach (var slot in slotsInHotbar)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.itemAmount < stackLimit)
            {
                itemCount += itemInSlot.itemAmount;
            }
        }

        foreach (var slot in slotsInInventory)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.itemAmount < stackLimit)
            {
                itemCount += itemInSlot.itemAmount;
            }
        }

        return itemCount;
    }

    public bool RemoveItem(Item item)
    {
        return ItemIsInInventory(item) || TryToRemoveItemFromInventory(item);
    }
}