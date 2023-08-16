using System;
using System.Collections;
using System.Collections.Generic;
using IsopodaFramework.GameSpecifics;
using UnityEngine;

public class CookingManager : Singleton<CookingManager>
{
    private Recipe currentRecipe;

    [SerializeField] private CookingInformation cookingUI;
    
    [SerializeField] private int amountToCook = 1;

    [SerializeField] private GameObject recipes;
    List<RecipieItem> recipeList = new List<RecipieItem>();

    private void Start()
    {
        foreach (Transform child in recipes.transform)
        {
            recipeList.Add(child.GetComponent<RecipieItem>());
        }
    }

    public void OnRecipeClicked(Recipe newRecipe)
    {
        if(currentRecipe == newRecipe) return;
        
        amountToCook = 1;

        currentRecipe = newRecipe;
        
        cookingUI.OnNewRecipeClicked(currentRecipe);
        cookingUI.UpdateAmountText(amountToCook);
    }

    public void CookItem()
    {
        if (currentRecipe.CanCraft(amountToCook))
        {
            foreach (Ingredient ingredient in currentRecipe.ingredients)
            {
                for (int i = 0; i < ingredient.Amount; i++)
                {
                    InventoryManager.Instance.RemoveItem(ingredient.Item);
                }
            }

            InventoryManager.Instance.AddItem(currentRecipe.foodToCreate);

            foreach (RecipieItem recipe in recipeList)
            {
                recipe.CheckIfCraftable();
            }
        }
    }
    
    public void IncreaseAmountToCook()
    {
        if (currentRecipe.CanCraft(amountToCook + 1))
        {
            amountToCook++;
            cookingUI.UpdateAmountText(amountToCook);
        }
    }
    
    public void DecreaseAmountToCook()
    {
        if (amountToCook > 1)
        {
            amountToCook--;
            cookingUI.UpdateAmountText(amountToCook);

        }
    }
}
