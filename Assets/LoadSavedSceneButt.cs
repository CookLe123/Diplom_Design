using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSavedSceneButt : MonoBehaviour
{

    public GameObject saveManager;


    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        saveManager.GetComponent<SaveManager>().LoadGame();

    }
}
