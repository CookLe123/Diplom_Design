using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyFurniture : MonoBehaviour
{
    public GameObject[] uiObject;

    void Start()
    {
        transform.GetComponentInChildren<Button>().onClick.AddListener(OffUi);
    }

    void OffUi()
    {
        uiObject[0].SetActive(false);
        uiObject[1].SetActive(false);
    }
}
