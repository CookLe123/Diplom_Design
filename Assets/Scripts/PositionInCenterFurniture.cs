using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionInCenterFurniture : MonoBehaviour
{
    GameObject furniture;

    Bounds bound;

    void Start()
    {
        furniture = transform.parent.Find("Furniture").gameObject;
        bound = furniture.GetComponent<MeshFilter>().sharedMesh.bounds;
    }
    void Update()
    {
        transform.position = furniture.transform.position;
    }

}
