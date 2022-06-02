using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSceneButt : MonoBehaviour
{

    public GameObject confirmationUI;

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(ShowConfirmation);
    }

    void ShowConfirmation()
    {
        confirmationUI.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
