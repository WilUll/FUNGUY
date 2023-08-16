using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text amountText;

    public void Init(Ingredient ingredient)
    {
        image.sprite = ingredient.Item.image;
        amountText.text = ingredient.Amount.ToString();
    }
}
