using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AgreedSaveButt : MonoBehaviour
{

    public GameObject buttonMenu;

    public GameObject saveManager;
    

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(SaveScene);
    }

    void SaveScene()
    {

        GameObject[] objectList = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> Objects = new List<GameObject>(objectList.Length);

        saveManager.GetComponent<SaveManager>().ObjectsSaves = Objects;
        saveManager.GetComponent<SaveManager>().SaveGame();
        
        
        buttonMenu.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
