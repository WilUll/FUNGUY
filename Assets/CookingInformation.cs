using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookingInformation : MonoBehaviour
{
    [SerializeField] private Image recipeImage;
    [SerializeField] private TMP_Text title;
    [SerializeField] private GameObject ingredientHolder;

    [SerializeField] private GameObject recipeItemPrefab;
    [SerializeField] private TMP_Text amountText;
    
    

    public void OnNewRecipeClicked(Recipe newRecipe)
    {
        UpdateUI(newRecipe);
    }

    private void UpdateUI(Recipe currentRecipe)
    {
        var food = currentRecipe.foodToCreate;
        recipeImage.sprite = food.image;
        title.text = food.name;
        UpdateRecipeHolder(currentRecipe);
    }
    
    public void UpdateAmountText(int amount)
    {
        amountText.text = amount.ToString();
    }

    private void UpdateRecipeHolder(Recipe currentRecipe)
    {
        foreach (Transform child in ingredientHolder.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var ingredient in currentRecipe.ingredients)
        {
            var go = Instantiate(recipeItemPrefab);
            go.transform.SetParent(ingredientHolder.transform);
            var recipeItem = go.GetComponent<IngredientUI>();
            recipeItem.Init(ingredient);
        }
    }
}
