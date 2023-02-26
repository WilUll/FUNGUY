using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private string characterName;
    [SerializeField] private Sprite portrait;
    [SerializeField] private AudioClip voice;

    public string CharacterName => characterName;
    public Sprite Portrait => portrait;
    public AudioClip Voice => voice;
}
