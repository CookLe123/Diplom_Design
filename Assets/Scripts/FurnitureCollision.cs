using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureCollision : MonoBehaviour
{
    Collider colliders;

    Bounds bound;

    void Start()
    {
        colliders = transform.GetComponent<Collider>();
        bound = transform.GetComponent<MeshFilter>().sharedMesh.bounds;
    }

    void FixedUpdate()
    {
        MyCollisions();
    }

    private void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapBox(colliders.bounds.center, Vector3.Scale(colliders.bounds.size, transform.localScale)/2, Quaternion.identity);

        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].tag == "Walls" || hitColliders[i].tag == "Floor")
            {
                Debug.Log(bound.size);
                Vector3 positionDifference = hitColliders[i].ClosestPoint(colliders.bounds.center) - colliders.bounds.center;
                Vector3 normal = positionDifference.normalized;
                Vector3 scaleObject = Vector3.Scale(Vector3.Scale(colliders.bounds.size, transform.localScale), normal)/2;
                transform.position += positionDifference-scaleObject;
            }
            i++;
        }
        
    }
}
