using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridNotReady : MonoBehaviour
{

    public GameObject grid;
    public GameObject canvasUI;
    public GameObject buttons;

    bool buttonclick = false;

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(BackToEditing);
    }

    private void Update()
    {
        if (buttonclick)
        {
           buttons.transform.Rotate(new Vector3(0, 1, 0));
            if (Mathf.Round(buttons.transform.rotation.eulerAngles.y) == 0)
            {
                buttonclick = false;
                canvasUI.SetActive(false);
            }
            if (Mathf.Round(grid.transform.rotation.eulerAngles.y) != 359)
            {
                grid.transform.Rotate(new Vector3(0, 1, 0));
            } 
        }
    }

    void BackToEditing()
    {
        buttonclick = true;  
    }
}
