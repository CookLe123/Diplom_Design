using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{

    public GameObject openMenu;

    public float offset;

    void Start()
    {
        transform.GetComponentInChildren<Button>().onClick.AddListener(SpawnMenu);
    }

    void SpawnMenu()
    {
        Instantiate(openMenu,transform.position+Vector3.up*offset,transform.rotation);
        DestroyObject();
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
