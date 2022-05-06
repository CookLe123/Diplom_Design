using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddingFurnitureToList : MonoBehaviour
{
    string path = "Prefabs/Furniture/";
    GameObject[] allFurniture;
    Vector3 pos;
    void Start()
    {
        allFurniture = Resources.LoadAll<GameObject>(path);
        for (int i=0;i<allFurniture.Length;i++)
        {
            Instantiate(transform.Find("CreateFurniture"),transform);
            RectTransform button = transform.GetChild(i + 2).gameObject.GetComponent<RectTransform>();
            button.gameObject.SetActive(true);
            button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text += allFurniture[i].name;
            button.anchoredPosition -= (i-2)*Vector2.down*(5+button.sizeDelta.y);
            var init = button.gameObject.GetComponent<InitFurniture>();
            init.Init(allFurniture[i],button.gameObject.GetComponent<Button>());
        }
    }


}
