using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public Item foodToCreate;
    
    public Ingredient[] ingredients;
}

[Serializable]
public struct Ingredient
{
    public Item Item;
    public int Amount;
}