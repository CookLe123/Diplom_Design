using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddingMaterialToList : MonoBehaviour
{
    string path = "Materials/";

    Material[] allMaterials;

    void Start()
    {
        allMaterials = Resources.LoadAll<Material>(path);

        for (int i = 0; i < allMaterials.Length; i++)
        {
            Instantiate(transform.Find("Material"), transform);

            RectTransform material = transform.GetChild(i + 3).gameObject.GetComponent<RectTransform>();
            material.gameObject.SetActive(true);

            material.gameObject.transform.GetChild(0).GetComponentInChildren<Text>().text += " " + allMaterials[i].name;
            material.gameObject.transform.GetChild(1).GetComponent<Image>().material = allMaterials[i];

            material.anchoredPosition += i*Vector2.down * (5 + material.gameObject.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y);

            var init = material.transform.GetChild(0).GetComponent<InitMaterial>();
            init.Init(allMaterials[i], material.transform.GetChild(0).GetComponent<Button>());

        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
