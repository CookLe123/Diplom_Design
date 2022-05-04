using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionInCenterFurniture : MonoBehaviour
{
    GameObject furniture;
    void Start()
    {
        furniture = transform.parent.Find("Cube").gameObject;
        transform.position = furniture.transform.position;
    }
    void Update()
    {
        transform.position = transform.parent.Find("Cube").position;
    }
}
