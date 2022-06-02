using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleHint : MonoBehaviour
{

    public GameObject Hint;

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(ShowHint);
    }

    void ShowHint()
    {
        Hint.SetActive(true);
    }

}
