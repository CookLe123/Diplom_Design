using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOverFurniture : MonoBehaviour
{
    GameObject furniture;
    Vector3 pos;
    Vector3 standartPos;
    void Start()
    {
        furniture = transform.root.Find("Cube").gameObject;
        standartPos = new Vector3(furniture.transform.localPosition.x, furniture.transform.localPosition.y - furniture.transform.localScale.y / 4, furniture.transform.localPosition.z - furniture.transform.localScale.z / 2 - 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        FurnitureTransform();
        transform.localPosition = pos;
    }

    void FurnitureTransform()
    {
        if (transform.name == "All_Ui")
        {
            pos = standartPos;
        }
        else
        pos = new Vector3(furniture.transform.position.x, furniture.transform.position.y + furniture.transform.lossyScale.y / 2, furniture.transform.position.z);
    }
}
