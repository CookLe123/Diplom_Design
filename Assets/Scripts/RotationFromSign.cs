using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFromSign : MonoBehaviour
{
    GameObject rotationSign;

    Quaternion rot;

    void Start()
    {
        rotationSign = transform.root.Find("rotation").gameObject;
    }

    void Update()
    {
        All_transform();

        transform.rotation = rot;
    }

    private void All_transform()
    {
        rot = new Quaternion(rotationSign.transform.rotation.x, rotationSign.transform.rotation.y, rotationSign.transform.rotation.z, rotationSign.transform.rotation.w);
    }
}
