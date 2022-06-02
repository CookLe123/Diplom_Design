using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButt : MonoBehaviour
{

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(QuitGame);
    }


    void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
