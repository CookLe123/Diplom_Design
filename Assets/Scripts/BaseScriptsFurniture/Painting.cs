using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    RaycastHit hit;
    public List<string> collidingObjects;

    private void Update()
    {
        if (Physics.Raycast(transform.position, -transform.forward, out hit, 1f))
        {
            if (collidingObjects.Contains(hit.transform.gameObject.tag) && transform.parent != null)
            {
                hit.transform.gameObject.GetComponent<MeshRenderer>().material = transform.GetComponent<MeshRenderer>().material;
            }
        }
        Debug.DrawRay(transform.position, -transform.forward,Color.black);
    }
}
