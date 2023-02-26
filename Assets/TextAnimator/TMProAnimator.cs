using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class TMProAnimator : MonoBehaviour
{
    [SerializeField] private TMP_Text textContainer;

    private Regex regex = new Regex(@"<wobbly>(.*?)</wobbly>");
    
    void Start()
    {
        string text = textContainer.text;
        var match = Regex.Match(text, regex.ToString()).Groups[1].Value;
        Debug.Log(text + "  " + match);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
