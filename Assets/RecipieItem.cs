using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecipieItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Recipe recipe;

    public bool CanCraft()
    {
        if (InventoryManager.Instance != null)
        {
            foreach (Ingredient ingredient in recipe.ingredients)
            {
                if (InventoryManager.Instance.TimesItemIsInInventory(ingredient.Item) < ingredient.Amount)
                {
                    return false;
                }
            }

            return true;
        }

        return false;
    }
    
    //TODO
    //Craft the item
    //Fix UI
    //Add more recipes


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(CanCraft());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
