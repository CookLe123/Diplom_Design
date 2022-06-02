using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridField : MonoBehaviour
{
    public GameObject wall;
    GameObject link;
    Vector3 size;
    GameObject grid;
    GameObject emptyField;

    private void OnMouseDown()
    {
        link = Instantiate(wall, transform.position, transform.rotation, transform);
        size = transform.GetComponent<BoxCollider>().size;
        link.transform.localScale = new Vector3(size.x, 1f, size.z);
    }

    public void DestroyWall()
    {
        if (link)
        {
            link.GetComponent<DestroyObject>().DestroyObjects();
        }
    }

    public void DeAttachParent()
    {
        transform.root.GetChild(0).parent = null;
        transform.root.localScale = new Vector3(1f, 3f, 1f);
        transform.root.position = new Vector3(0, 0, 0);
        transform.root.Rotate(new Vector3(0,0,-90));
    }

    public void BuildWall()
    {
        if (link)
        {
            grid = transform.parent.gameObject;
            transform.parent = null;
            grid.GetComponent<DestroyObject>().DestroyObjects();
            emptyField = link.transform.parent.gameObject;
            link.transform.parent = null;
            emptyField.GetComponent<DestroyObject>().DestroyObjects();
            link.transform.position = new Vector3(link.transform.position.x,link.transform.localScale.y/2,link.transform.position.z);
        }
    }
}
