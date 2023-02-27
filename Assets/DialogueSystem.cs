using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private DialogueNode StartingNode;
    [SerializeField] private TMP_Text textContainer;
    [SerializeField] private GameObject choiceButton;
    [SerializeField] private RectTransform choiceParent;

    private DialogueNode currentNode;
    // Start is called before the first frame update
    void Start()
    {
        NextNode(StartingNode);
    }

    public void NextNode(DialogueNode dialogueNode)
    {
        choiceParent.gameObject.SetActive(false);
        ClearChoiceButtons();
        currentNode = dialogueNode;
        var text = currentNode.SetupNode(textContainer);
        StartCoroutine(AnimateText(text));
        if (currentNode.GetType() == typeof(ChoiceNode))
        {
            Debug.Log("In Right Pos");
            var choiceNode = (ChoiceNode)currentNode;
            foreach (var choiceNodeChoice in choiceNode.Choices)
            {
                ChoiceButton button = Instantiate(choiceButton).GetComponent<ChoiceButton>();
                button.SetupButton(choiceNodeChoice.ChoiceText);
                button.GetComponent<Button>().onClick.AddListener(() => NextNode(choiceNodeChoice.NextNode));
                button.transform.SetParent(choiceParent);
            }
        }
    }

    private IEnumerator AnimateText(string text)
    {
        textContainer.text = "";
        foreach (var character in text)
        {
            textContainer.text += character;
            yield return new WaitForSeconds(0.05f);
        }

        if (currentNode.GetType() == typeof(ChoiceNode))
        {
            choiceParent.gameObject.SetActive(true);
        }
    }

    void ClearChoiceButtons()
    {
        var buttons = choiceParent.GetComponentsInChildren<Button>();

        foreach (var button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
}
