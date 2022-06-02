using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenuButton : MonoBehaviour
{

    public GameObject selectedMenu;

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(OpenMenu);
    }

    void OpenMenu()
    {
        transform.root.GetComponent<DestroyObject>().DestroyObjects();
        Instantiate(selectedMenu,transform.position,transform.rotation);
    }

}
