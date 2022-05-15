using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject Menu;

    bool managerStart = false;

    public Camera MainCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !managerStart)
            managerStart = true;
    }

    void FixedUpdate()
    {
        if (!managerStart)
            return;
        Instantiate(Menu, MainCamera.transform.position+Vector3.forward+Vector3.down, MainCamera.transform.rotation);
        managerStart = false;
    }
}
