using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionInCenterFurniture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.parent.Find("Cube").transform.position;
    }
}
