using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;


public class SpawnFurniture : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public Color colorPrevious, colorOnCovered;
    public GameObject FurnitureObject;
    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        //laserPointer.PointerClick += PointerClick;
        colorOnCovered = Color.cyan;
        colorPrevious = Color.white;
    }

    //public void PointerClick(object sender, PointerEventArgs e)
    //{
    //    if (e.target.name == "Button_CubeAppear")
    //    {
    //        Debug.Log("button was clicked");
    //    }
    //    Debug.Log("Something clicked");
    //}

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Button_CubeAppear")
        {
            SpawnObjectFurniture();
            ColorBlock colors = e.target.GetComponent<Button>().colors;
            colors.normalColor = colorOnCovered;
            e.target.GetComponent<Button>().colors = colors;
            e.target.gameObject.SetActive(false);
        }
        else if (e.target.name == "Reset_position")
        {
            var skript = e.target.root.Find("Cube").GetComponent<FurnitureTransform>();
            skript.ResetPosition();
        }
        else if (e.target.name == "Reset_rotation")
        {
            var skript = e.target.root.Find("Cube").GetComponent<FurnitureTransform>();
            skript.ResetRotation();
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Button_CubeAppear")
        {
            ColorBlock colors = e.target.GetComponent<Button>().colors;
            colors.normalColor = colorPrevious;
            e.target.GetComponent<Button>().colors = colors;
        }
    }
 
    public void SpawnObjectFurniture()
    {
        Instantiate(FurnitureObject);
        GameObject Furniture = FurnitureObject.transform.Find("Cube").gameObject;
    }




}
