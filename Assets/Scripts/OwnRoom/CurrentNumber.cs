using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurrentNumber : MonoBehaviour
{
    public int Currentnumb;
    public UnityEvent NumberChange;
    // Start is called before the first frame update
    void Start()
    {
        Currentnumb = 0;
        NumberChange.AddListener(ChangedNumber);
    }

    void ChangedNumber()
    {
        if (Currentnumb == 2)
        {
            Currentnumb = 0;
        }
    }


}
