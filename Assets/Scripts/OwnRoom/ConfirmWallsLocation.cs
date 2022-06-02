using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmWallsLocation : MonoBehaviour
{
    public string creativeScene;
    public GameObject player;
    public GameObject[,] wallObjects;
    public GameObject gridReadyButton;
    public GameObject menuPlate;
    GameObject link;
    public Camera mainCamera;
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(ConfirmingWalls);
    }

    void ConfirmingWalls()
    {
        link = Instantiate(menuPlate);
        link.GetComponent<MenuManager>().mainCamera = mainCamera;
        wallObjects = gridReadyButton.GetComponent<GridReady>().linkObject;
        wallObjects[0,0].GetComponent<GridField>().DeAttachParent();
        for (int i = 0; i < wallObjects.GetLength(0); i++)
        {
            for (int j = 0; j < wallObjects.GetLength(1); j++)
            {
                wallObjects[i,j].GetComponent<GridField>().BuildWall();
            }
        }
    }

}
