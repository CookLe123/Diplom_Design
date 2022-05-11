using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionOverFurniture : MonoBehaviour
{
    GameObject furniture;

    Vector3 pos;

    Vector3 standartPos;

    Bounds bound;

    GameObject maincamera;

    Vector3 poscamera;

    Vector3 furnitureScale;

    GameObject scrollbarObject;

    Scrollbar valueOfScale;

    public bool zaxis = false;

    void Start()
    {
        furniture = transform.root.Find("Furniture").gameObject;

        bound = furniture.GetComponent<MeshFilter>().sharedMesh.bounds;

        standartPos = furniture.transform.position;

        furnitureScale = furniture.transform.localScale;

        maincamera = GameObject.Find("FallbackObjects");

        valueOfScale = transform.Find("UI_ForCube/Scrollbar").GetComponent<Scrollbar>();

        scrollbarObject = transform.Find("UI_ForCube/Scrollbar").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        FurnitureTransform();

        transform.localPosition = pos;
    }

    private void FurnitureTransform()
    {
        if (transform.name == "All_Ui")
        {
            poscamera = new Vector3(maincamera.transform.position.x,transform.position.y, maincamera.transform.position.z);

            float valuex = scrollbarObject.GetComponent<ScaleFromScrollbar>().zscale.x;

            float valuez = scrollbarObject.GetComponent<ScaleFromScrollbar>().xscale.z;

            if (Vector3.Angle(poscamera, -furniture.transform.forward) <= 45)
            {
                zaxis = true;
                valuex = valuex/furnitureScale.x-1;
                valueOfScale.value = valuex;

                transform.parent.rotation = furniture.transform.rotation;
                transform.rotation = furniture.transform.rotation;
                pos = new Vector3(standartPos.x, standartPos.y - bound.size.y * furniture.transform.lossyScale.y / 1.5f, standartPos.z - bound.size.z * furniture.transform.lossyScale.z / 2 - 0.1f);

            }
            else if (Vector3.Angle(poscamera, furniture.transform.forward) <= 45)
            {
                zaxis = true;
                valuex = valuex / furnitureScale.x - 1;
                valueOfScale.value = valuex;

                transform.parent.rotation = furniture.transform.rotation;
                transform.rotation = furniture.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
                pos = new Vector3(standartPos.x, standartPos.y - bound.size.y * furniture.transform.lossyScale.y / 1.5f, standartPos.z + bound.size.z * furniture.transform.lossyScale.z / 2 + 0.1f);

            }
            else if (Vector3.Angle(poscamera, furniture.transform.right) <= 45)
            {
                zaxis = false;
                valuez = valuez / furnitureScale.z - 1;
                valueOfScale.value = valuez;

                transform.parent.rotation = furniture.transform.rotation;
                transform.rotation = furniture.transform.rotation * Quaternion.Euler(0f, -90f, 0f);
                pos = new Vector3(standartPos.x + bound.size.x * furniture.transform.lossyScale.x / 2 + 0.1f, standartPos.y - bound.size.y * furniture.transform.lossyScale.y / 1.5f, standartPos.z );

            }
            else if (Vector3.Angle(poscamera, -furniture.transform.right) <= 45)
            {
                zaxis = false;
                valuez = valuez / furnitureScale.z - 1;
                valueOfScale.value = valuez;

                transform.parent.rotation = furniture.transform.rotation;
                transform.rotation = furniture.transform.rotation * Quaternion.Euler(0f, 90f, 0f);
                pos = new Vector3(standartPos.x - bound.size.x * furniture.transform.lossyScale.x / 2 - 0.1f, standartPos.y - bound.size.y * furniture.transform.lossyScale.y / 1.5f, standartPos.z);

            }
           
        }
        else
        pos = new Vector3(furniture.transform.position.x, furniture.transform.position.y + furniture.transform.lossyScale.y / 2, furniture.transform.position.z);
    }
}
