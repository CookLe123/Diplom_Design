using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;

    bool managerStart = false;

    public KeyCode keyMenuAppear;

    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyMenuAppear) && !managerStart)
            managerStart = true;
    }

    void FixedUpdate()
    {
        if (!managerStart)
            return;
        Instantiate(menu, mainCamera.transform.position+Vector3.forward+Vector3.down, mainCamera.transform.rotation);
        managerStart = false;
    }
}
