using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureCollision : MonoBehaviour
{
    Collider colliders;

    Bounds bound;

    public List<string> collidingObjects;

    public int delitel;
    float height;

    void Start()
    {
        colliders = transform.GetComponent<Collider>();
        bound = transform.GetComponent<MeshFilter>().sharedMesh.bounds;
        height = transform.position.y;
    }

    void FixedUpdate()
    {
        MyCollisions();
    }

    private void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapBox(colliders.bounds.center, Vector3.Scale(colliders.bounds.size, transform.localScale)/ delitel, Quaternion.identity);

        int i = 0;
        while (i < hitColliders.Length)
        {
            if(collidingObjects.Contains(hitColliders[i].tag))
            {
                Vector3 positionDifference = hitColliders[i].ClosestPoint(colliders.bounds.center) - colliders.bounds.center;
                Vector3 normal = positionDifference.normalized;
                Vector3 scaleObject = Vector3.Scale(Vector3.Scale(colliders.bounds.size, transform.localScale), normal)/ delitel;
                transform.position += positionDifference-scaleObject;
            }
            i++;
        }
        if (transform.position.y == height && transform.gameObject.TryGetComponent(out Rigidbody rb))
        {
            rb.detectCollisions = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
}
