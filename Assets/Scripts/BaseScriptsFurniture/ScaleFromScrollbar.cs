using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleFromScrollbar : MonoBehaviour
{
    Scrollbar currentScale;

    GameObject rootfurniture;

    Vector3 furnitureScale,totalScale;

    bool zaxis;

    public Vector3 zscale, xscale;

    void Start()
    {
        currentScale = transform.GetComponent<Scrollbar>();
        rootfurniture = transform.root.Find("Furniture").gameObject;
        furnitureScale = rootfurniture.transform.localScale;
        currentScale.onValueChanged.AddListener(ChangedValue);
        zscale = Vector3.Scale(furnitureScale, rootfurniture.transform.right);
        xscale = Vector3.Scale(furnitureScale, rootfurniture.transform.forward);

    }

    private void ChangedValue(float value)
    {
        GameObject ui = transform.root.Find("Ui_elements/All_Ui").gameObject;
        zaxis = ui.GetComponent<PositionOverFurniture>().zaxis;

        if (zaxis)
        {
            zscale = furnitureScale.x * (1 + value) * Vector3.right;
        }
        else xscale = furnitureScale.z * (1 + value) * Vector3.forward;

        rootfurniture.transform.localScale = new Vector3(zscale.x, furnitureScale.y,  xscale.z);
    }
    
}
