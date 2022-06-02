using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseData : MonoBehaviour
{

    public Material gridMaterial;
    // Start is called before the first frame update
    void Start()
    {
        gridMaterial.mainTextureScale = new Vector2(1,1);
    }

}
