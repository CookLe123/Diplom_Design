using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitMaterial : MonoBehaviour
{
    private Material material;

    public void Init(Material mat, Button button)
    {
        material = mat;

        button.onClick.AddListener(AddMaterial);
    }

    private void AddMaterial()
    {
        GameObject.Find("brush 1").GetComponent<MeshRenderer>().material = material;

        var skript = transform.root.GetComponent<AddingMaterialToList>();
        skript.DestroyObject();
    }
}
