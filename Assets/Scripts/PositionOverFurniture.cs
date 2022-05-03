using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOverFurniture : MonoBehaviour
{
    GameObject furniture;
    Vector3 pos;
    void Start()
    {
        furniture = transform.root.Find("Cube").gameObject;
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
            pos = new Vector3(furniture.transform.position.x , furniture.transform.position.y - furniture.transform.lossyScale.y / 4, furniture.transform.position.z - furniture.transform.lossyScale.z /2 -0.1f);
        }
        else
        pos = new Vector3(furniture.transform.position.x, furniture.transform.position.y + furniture.transform.lossyScale.y / 2, furniture.transform.position.z);
    }
}
