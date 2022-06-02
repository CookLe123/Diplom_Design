using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFromSign : MonoBehaviour
{
    public GameObject rotationSign;

    Quaternion rot;

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
