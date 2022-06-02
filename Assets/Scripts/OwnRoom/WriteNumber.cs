using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class WriteNumber : MonoBehaviour
{
    public GameObject inputField;
    public GameObject inputField1;
    public GameObject inputField2;
    
    public Material materialGrid;
    

    int currentNumber;

    char[] currentStroke;
    string modifiedStroke;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(WriteNumb);
    }

    void WriteNumb()
    {
        currentNumber = inputField1.GetComponent<CurrentNumber>().Currentnumb;
        currentStroke = inputField1.GetComponent<Text>().text.ToCharArray();
        currentStroke[currentNumber] = transform.GetComponentInChildren<TextMeshProUGUI>().text[0];
        modifiedStroke = new string(currentStroke);
        inputField1.GetComponent<Text>().text = modifiedStroke;
        inputField1.GetComponent<CurrentNumber>().Currentnumb += 1;
        inputField1.GetComponent<CurrentNumber>().NumberChange.Invoke();
        try
        {
            materialGrid.mainTextureScale = new Vector2(int.Parse(inputField.GetComponent<Text>().text), int.Parse(inputField2.GetComponent<Text>().text));
        }
        catch (FormatException)
        {

        }
    }
}
