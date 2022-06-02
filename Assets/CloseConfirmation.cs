using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseConfirmation : MonoBehaviour
{

    public GameObject buttonMenu;

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(CloseConfirm);
    }

    void CloseConfirm()
    {
        buttonMenu.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }

}
