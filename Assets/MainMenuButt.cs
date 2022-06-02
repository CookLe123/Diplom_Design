using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButt : MonoBehaviour
{

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(LoadMainMenu);
    }

    void LoadMainMenu()
    {
        transform.root.GetComponent<DestroyObject>().DestroyObjects();
        SceneManager.LoadScene((int)SceneManag.SceneList.MainMenu);
    }

}
