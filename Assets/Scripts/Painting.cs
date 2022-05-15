using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    RaycastHit hit;
    private void Update()
    {
        if (Physics.Raycast(transform.position, -transform.forward, out hit, 1f))
        {
            if ((hit.transform.gameObject.tag == "Floor" || hit.transform.gameObject.tag == "Walls" || hit.transform.gameObject.name == "Furniture") && transform.parent != null)
            {
                hit.transform.gameObject.GetComponent<MeshRenderer>().material = transform.GetComponent<MeshRenderer>().material;
            }
        }
        Debug.DrawRay(transform.position, -transform.forward,Color.black);
    }
}
