using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StandartSceneButt : MonoBehaviour
{

    public GameObject sceneManag;

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(LoadStandartScene);
    }


    void LoadStandartScene()
    {
        SceneManager.LoadScene((int)SceneManag.SceneList.SampleScene);
    }
}
