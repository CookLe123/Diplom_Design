using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddingMaterialToList : MonoBehaviour
{
    public string path;

    public GameObject materialObject;

    public int serialNumber;
    public float offsetHeight;

    Material[] allMaterials;

    void Start()
    {
        allMaterials = Resources.LoadAll<Material>(path);

        for (int i = 0; i < allMaterials.Length; i++)
        {
            Instantiate(materialObject, transform);

            RectTransform material = transform.GetChild(i + serialNumber).gameObject.GetComponent<RectTransform>();
            material.gameObject.SetActive(true);

            material.gameObject.transform.GetChild(0).GetComponentInChildren<Text>().text += " " + allMaterials[i].name;
            material.gameObject.transform.GetChild(1).GetComponent<Image>().material = allMaterials[i];

            material.anchoredPosition += i*Vector2.down * (offsetHeight + material.gameObject.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y);

            var init = material.transform.GetChild(0).GetComponent<InitMaterial>();
            init.Init(allMaterials[i], material.transform.GetChild(0).GetComponent<Button>());

        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
