using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleFromScrollbar : MonoBehaviour
{
    Scrollbar currentScale;
    GameObject rootfurniture;
    Vector3 furnitureScale,totalScale;
    bool front;
    bool back;
    bool right;
    bool left;
    // Start is called before the first frame update
    void Start()
    {
        currentScale = transform.GetComponent<Scrollbar>();
        rootfurniture = transform.root.Find("Furniture").gameObject;
        furnitureScale = rootfurniture.transform.localScale;
        currentScale.onValueChanged.AddListener(ChangedValue);
    }

    void ChangedValue(float value)
    {
        front = transform.root.Find("Ui_elements/All_Ui").GetComponent<PositionOverFurniture>().front;
        right = transform.root.Find("Ui_elements/All_Ui").GetComponent<PositionOverFurniture>().right;
        left = transform.root.Find("Ui_elements/All_Ui").GetComponent<PositionOverFurniture>().left;
        back = transform.root.Find("Ui_elements/All_Ui").GetComponent<PositionOverFurniture>().back;
        if (front || back)
        {
            totalScale = Vector3.right;
        }
        else if (right || left)
        {
            totalScale = Vector3.forward;
        }
        rootfurniture.transform.localScale = furnitureScale + totalScale * value;
    }
    
}
