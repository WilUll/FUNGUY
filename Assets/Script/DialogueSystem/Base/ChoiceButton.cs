using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] private TMP_Text buttonText;
    public void SetupButton(string textOnButton)
    {
        buttonText.text = textOnButton;
    }
}
