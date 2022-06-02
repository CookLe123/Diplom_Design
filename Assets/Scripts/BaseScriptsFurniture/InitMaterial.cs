using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitMaterial : MonoBehaviour
{
    private Material material;

    GameObject brush;

    private void Start()
    {
        brush = GameObject.Find("brush 1");
    }

    public void Init(Material mat, Button button)
    {
        material = mat;

        button.onClick.AddListener(AddMaterial);
    }

    private void AddMaterial()
    {
        brush.GetComponent<MeshRenderer>().material = material;

        var skript = transform.root.GetComponent<AddingMaterialToList>();
        skript.DestroyObject();
    }
}
