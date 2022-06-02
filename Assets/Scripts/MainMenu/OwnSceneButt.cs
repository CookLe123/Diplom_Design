using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OwnSceneButt : MonoBehaviour
{

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(LoadOwnScene);
    }

    void LoadOwnScene()
    {
        SceneManager.LoadScene((int)SceneManag.SceneList.Menu);
    }

}
