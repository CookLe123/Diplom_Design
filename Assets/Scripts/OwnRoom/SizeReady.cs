using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SizeReady : MonoBehaviour
{

    public GameObject grid;
    public GameObject canvasUI;
    bool buttonclicked = false;

    public string zeroWarning;
    public string emptyWarning;

    public Material materialGrid;

    GameObject inputField2;
    GameObject inputField;

    public GameObject warningObject;
    public GameObject warningText;

    public GameObject anyButton;

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(OffUI);
    }

    private void Update()
    {
        if (buttonclicked)
        {
            transform.root.Rotate(new Vector3(0,-1,0));
            if (Mathf.Round(transform.root.rotation.eulerAngles.y) == 180)
            {
                buttonclicked = false;
            }
            if (Mathf.Round(grid.transform.rotation.eulerAngles.y) != 270)
            {
                grid.transform.Rotate(new Vector3(0, -1, 0));
            }
            else canvasUI.SetActive(true);
        }
    }

    void OffUI()
    {
        inputField2 = anyButton.GetComponent<WriteNumber>().inputField2;
        inputField = anyButton.GetComponent<WriteNumber>().inputField;
        try
        {
            materialGrid.mainTextureScale = new Vector2(int.Parse(inputField.GetComponent<Text>().text), int.Parse(inputField2.GetComponent<Text>().text));
            if (materialGrid.mainTextureScale == new Vector2(0, 0))
                throw new Exception();
            else
            { 
                buttonclicked = true;
                warningObject.SetActive(false);
            }
        }
        catch (FormatException)
        {
            warningObject.SetActive(true);
            warningText.GetComponent<TextMeshProUGUI>().text = emptyWarning;
        }
        catch (Exception)
        {
            warningObject.SetActive(true);
            warningText.GetComponent<TextMeshProUGUI>().text = zeroWarning;
        }
        
    }

}
