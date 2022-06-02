using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionOverFurniture : MonoBehaviour
{
    public GameObject furniture;

    Vector3 pos;
    Vector3 standartPos;

    Bounds bound;

    GameObject mainCamera;
    public string nameCamera;

    Vector3 posCamera;

    public GameObject scrollbarObject;
    Vector3 furnitureScale;
    Scrollbar valueOfScale;
    public int angle;

    public GameObject allUi;
    public float heightOffset;
    public float frontOffset;
    public float delitel;

    public bool zaxis = false;

    void Start()
    {
        bound = furniture.GetComponent<MeshFilter>().sharedMesh.bounds;
        standartPos = furniture.transform.position;
        furnitureScale = furniture.transform.localScale;
        valueOfScale = scrollbarObject.GetComponent<Scrollbar>();
        mainCamera = GameObject.Find(nameCamera);
    }

    // Update is called once per frame
    void Update()
    {
        FurnitureTransform();
        transform.localPosition = pos;
    }

    private void FurnitureTransform()
    {
        if (transform.name == allUi.name)
        {
            
            posCamera = new Vector3(mainCamera.transform.position.x,transform.position.y, mainCamera.transform.position.z);

            float valuex = scrollbarObject.GetComponent<ScaleFromScrollbar>().zscale.x;
            float valuez = scrollbarObject.GetComponent<ScaleFromScrollbar>().xscale.z;

            if (Vector3.Angle(posCamera, -furniture.transform.forward) <= angle)
            {
                zaxis = true;
                valuex = valuex/furnitureScale.x - 1;
                valueOfScale.value = valuex;

                transform.parent.rotation = furniture.transform.rotation;
                transform.rotation = furniture.transform.rotation * Quaternion.Euler(0f,0f,0f);
                pos = new Vector3(standartPos.x, standartPos.y - bound.size.y * furniture.transform.lossyScale.y / heightOffset, standartPos.z - bound.size.z * furniture.transform.lossyScale.z / delitel - frontOffset);

            }
            else if (Vector3.Angle(posCamera, furniture.transform.forward) <= angle)
            {
                zaxis = true;
                valuex = valuex / furnitureScale.x - 1;
                valueOfScale.value = valuex;

                transform.parent.rotation = furniture.transform.rotation;
                transform.rotation = furniture.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
                pos = new Vector3(standartPos.x, standartPos.y - bound.size.y * furniture.transform.lossyScale.y / heightOffset, standartPos.z + bound.size.z * furniture.transform.lossyScale.z / delitel + frontOffset);

            }
            else if (Vector3.Angle(posCamera, furniture.transform.right) <= angle)
            {
                zaxis = false;
                valuez = valuez / furnitureScale.z - 1;
                valueOfScale.value = valuez;

                transform.parent.rotation = furniture.transform.rotation;
                transform.rotation = furniture.transform.rotation * Quaternion.Euler(0f, -90f, 0f);
                pos = new Vector3(standartPos.x + bound.size.x * furniture.transform.lossyScale.x / delitel + frontOffset, standartPos.y - bound.size.y * furniture.transform.lossyScale.y / heightOffset, standartPos.z );

            }
            else if (Vector3.Angle(posCamera, -furniture.transform.right) <= angle)
            {
                zaxis = false;
                valuez = valuez / furnitureScale.z - 1;
                valueOfScale.value = valuez;

                transform.parent.rotation = furniture.transform.rotation;
                transform.rotation = furniture.transform.rotation * Quaternion.Euler(0f, 90f, 0f);
                pos = new Vector3(standartPos.x - bound.size.x * furniture.transform.lossyScale.x / delitel - frontOffset, standartPos.y - bound.size.y * furniture.transform.lossyScale.y / heightOffset, standartPos.z);

            }
           
        }
        else
        pos = new Vector3(furniture.transform.position.x, furniture.transform.position.y + furniture.transform.lossyScale.y - Vector3.up.y*delitel , furniture.transform.position.z);
    }
}
