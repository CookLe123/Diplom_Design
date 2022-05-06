using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOverFurniture : MonoBehaviour
{
    GameObject furniture;
    Vector3 pos;
    Vector3 standartPos;
    Bounds bound;
    GameObject maincamera;
    Vector3 poscamera;
    public bool front = false;
    public bool back = false;
    public bool right = false;
    public bool left = false;
    void Start()
    {
        furniture = transform.root.Find("Furniture").gameObject;
        bound = furniture.GetComponent<MeshFilter>().sharedMesh.bounds;
        standartPos = furniture.transform.position;
        maincamera = GameObject.Find("FallbackObjects");
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
            poscamera = new Vector3(maincamera.transform.position.x,transform.position.y, maincamera.transform.position.z);
            if (Vector3.Angle(poscamera, -furniture.transform.forward) <= 45)
            {
                transform.parent.rotation = furniture.transform.rotation;
                transform.rotation = furniture.transform.rotation;
                back = false;
                right = false;
                left = false;
                front = true;
            }
            else if (Vector3.Angle(poscamera, furniture.transform.forward) <= 45)
            {
                transform.parent.rotation = furniture.transform.rotation * Quaternion.Euler(0f,180f,0f);
                transform.rotation = furniture.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
                back = true;
                right = false;
                left = false;
                front = false;
            }
            else if (Vector3.Angle(poscamera, furniture.transform.right) <= 45)
            {
                transform.parent.rotation = furniture.transform.rotation * Quaternion.Euler(0f, -90f, 0f);
                transform.rotation = furniture.transform.rotation * Quaternion.Euler(0f, -90f, 0f);
                back = false;
                right = true;
                left = false;
                front = false;
            }
            else if (Vector3.Angle(poscamera, -furniture.transform.right) <= 45)
            {
                transform.parent.rotation = furniture.transform.rotation * Quaternion.Euler(0f, 90f, 0f);
                transform.rotation = furniture.transform.rotation * Quaternion.Euler(0f, 90f, 0f);
                back = false;
                right = false;
                left = true;
                front = false;
            }
            pos = new Vector3(standartPos.x, standartPos.y - bound.size.y * furniture.transform.lossyScale.y / 1.5f, standartPos.z - bound.size.z * furniture.transform.lossyScale.z / 2 - 0.1f);
        }
        else
        pos = new Vector3(furniture.transform.position.x, furniture.transform.position.y + furniture.transform.lossyScale.y / 2, furniture.transform.position.z);
    }
}
