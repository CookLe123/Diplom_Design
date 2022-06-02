using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionInCenterFurniture : MonoBehaviour
{
    public GameObject furniture;

    Bounds bound;

    void Start()
    {
        bound = furniture.GetComponent<MeshFilter>().sharedMesh.bounds;
    }

    void Update()
    {
        transform.position = furniture.transform.position;
    }

}
