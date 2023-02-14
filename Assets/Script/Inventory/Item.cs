using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [Header("Gameplay")]
    public ItemType type;
    public ActionType action;
    
    [Header("UI")]
    public Sprite image;
    public bool stackable = true;
}

public enum ItemType
{
    Tool,
    Mushroom,
    Food
}

public enum ActionType 
{
    Eat,
    Attack
}
