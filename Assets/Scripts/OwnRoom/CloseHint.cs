using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseHint : MonoBehaviour
{

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(DestroyHint);
    }

    void DestroyHint()
    {
        transform.parent.gameObject.SetActive(false);
    }

}
