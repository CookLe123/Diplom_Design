using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveInputField : MonoBehaviour
{
    public GameObject[] activeUI;
    public GameObject placeholder;
    public GameObject minePlaceholderImage;
    public GameObject outsiderPlaceHolderImage;

    public Color selected;
    public Color unselected;

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(GetActive);
    }

    void GetActive()
    {
        foreach(GameObject obj in activeUI)
        obj.GetComponent<WriteNumber>().inputField1 = placeholder;
        minePlaceholderImage.GetComponent<Image>().color = selected;
        outsiderPlaceHolderImage.GetComponent<Image>().color = unselected;
    }

    
}
