using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleFromScrollbar : MonoBehaviour
{
    Scrollbar currentScale;
    GameObject rootfurniture;
    Vector3 furnitureScale;
    // Start is called before the first frame update
    void Start()
    {
        currentScale = transform.GetComponent<Scrollbar>();
        rootfurniture = transform.root.Find("Cube").gameObject;
        furnitureScale = rootfurniture.transform.localScale;
        currentScale.onValueChanged.AddListener(ChangedValue);
    }

    void ChangedValue(float value)
    {
        rootfurniture.transform.localScale = furnitureScale * (1+value);
    }
    
}
