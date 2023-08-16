using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecipieItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Recipe recipe;

    private void Start()
    {
        GetComponent<Image>().sprite = recipe.foodToCreate.image;

    }

    public void CheckIfCraftable()
    {
        if (!recipe.CanCraft())
        {
            GetComponent<Image>().color = new Color(1,1,1, 0.5f);
        }
        else
        {
            GetComponent<Image>().color = new Color(1,1,1, 1);
        }
    }

    private void OnEnable()
    {
        CheckIfCraftable();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (recipe.CanCraft())
        {
            CookingManager.Instance.OnRecipeClicked(recipe);
        }
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
