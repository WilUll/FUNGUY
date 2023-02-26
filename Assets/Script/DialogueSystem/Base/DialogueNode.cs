using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/BaseNode")]
public class DialogueNode : ScriptableObject
{
    public string DialogueText;
    public DialogueNode NextNode;

    public virtual void SetupNode(TMP_Text textContainer)
    {
        textContainer.text = DialogueText;
    }
}
