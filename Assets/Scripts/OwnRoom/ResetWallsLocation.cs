using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetWallsLocation : MonoBehaviour
{
    public GameObject ReadyGridButton;
    public GameObject[,] wallObjects;
    int i = 0, j = 0;
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(ResetWalls);
    }

    void ResetWalls()
    {
        wallObjects = ReadyGridButton.GetComponent<GridReady>().linkObject;
        for (i = 0; i < wallObjects.GetLength(0); i++)
        {
            for (j = 0; j < wallObjects.GetLength(1); j++)
            {
                wallObjects[i, j].GetComponent<GridField>().DestroyWall();
            }
        }
    }
}
