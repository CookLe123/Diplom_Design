using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitFurniture : MonoBehaviour
{
    private GameObject furniture;
    public void Init(GameObject obj,Button button)
    {
        furniture = obj;
        button.onClick.AddListener(CreateFurniture);
    }
    private void CreateFurniture()
    {
        Instantiate(furniture);
    }

}
