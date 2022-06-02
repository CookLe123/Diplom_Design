using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridReady : MonoBehaviour
{

    public GameObject hint;
    public GameObject grid;
    public Material gridMaterial;
    public GameObject gridEmptyField;
    public GameObject buildingUI;
    public GameObject[,] linkObject;
    public GameObject sizeUI;
    

    Vector3 boxCollider;
    Vector2 scale;
    Vector3 size;
    Vector3 position;
  
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(OffUi);
        boxCollider = grid.GetComponent<BoxCollider>().size;
    }

    void OffUi()
    {
        hint.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        scale = gridMaterial.mainTextureScale;
        linkObject = new GameObject[(int)scale.x, (int)scale.y];
        size = new Vector3(boxCollider.x/scale.x,0.5f, boxCollider.z / scale.y);
        position = new Vector3(boxCollider.x/2-size.x/2, 0.5f, boxCollider.z/2-size.z/2);
        for (int i = 0; i < (int)scale.x; i++)
        {
            for (int j = 0; j < (int)scale.y; j++)
            {
                linkObject[i,j] = Instantiate(gridEmptyField, grid.transform.position,grid.transform.rotation,grid.transform);
                linkObject[i,j].transform.localScale = size;
                linkObject[i,j].transform.localPosition = new Vector3(position.x-size.x*i,position.y,position.z-size.z*j);
                linkObject[i,j].AddComponent<BoxCollider>();
            }
        }
        buildingUI.SetActive(true);
        sizeUI.GetComponent<DestroyObject>().DestroyObjects();
    }

}
