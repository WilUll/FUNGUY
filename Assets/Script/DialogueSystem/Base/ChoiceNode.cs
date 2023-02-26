using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/ChoiceNode")]
public class ChoiceNode : DialogueNode
{
    public Choice[] Choices;
}
