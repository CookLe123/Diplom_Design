using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddingFurnitureToList : MonoBehaviour
{
    public string path;

    public GameObject createFurnitureButton;

    public int serialNumber;
    public int marginNumber;

    GameObject[] allFurniture;

    void Start()
    {
        allFurniture = Resources.LoadAll<GameObject>(path);

        for (int i=0;i<allFurniture.Length;i++)
        {
            Instantiate(createFurnitureButton, transform);
            RectTransform button = transform.GetChild(i + serialNumber).gameObject.GetComponent<RectTransform>();
            button.gameObject.SetActive(true);
            button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text += allFurniture[i].name;
            button.anchoredPosition -= (i - serialNumber) *Vector2.down*(marginNumber + button.sizeDelta.y);
            var init = button.gameObject.GetComponent<InitFurniture>();
            init.Init(allFurniture[i],button.gameObject.GetComponent<Button>());
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
