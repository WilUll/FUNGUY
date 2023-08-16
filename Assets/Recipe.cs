using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public Item foodToCreate;
    
    public Ingredient[] ingredients;
    
    public bool CanCraft(float multiplier = 1)
    {
        if (InventoryManager.Instance != null)
        {
            foreach (Ingredient ingredient in ingredients)
            {
                if (InventoryManager.Instance.TimesItemIsInInventory(ingredient.Item) < ingredient.Amount * multiplier)
                {
                    return false;
                }
            }

            return true;
        }

        return false;
    }
}

[Serializable]
public struct Ingredient
{
    public Item Item;
    public int Amount;
}