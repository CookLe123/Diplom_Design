using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureTransform : MonoBehaviour
{
    GameObject rotationsign;

    private void Start()
    {
        rotationsign = transform.parent.Find("rotation").gameObject;
    }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
    }

    public void ResetRotation()
    {
        rotationsign.transform.rotation = new Quaternion(0,0,0,1);
    }

}
