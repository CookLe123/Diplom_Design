using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class InteractableBrush : MonoBehaviour
{
    private Interactable interactable;

    public GameObject materialMenu;

    Bounds bound;

    public GameObject cameraObject;

    public float delitel;

    public List<float> offset;

    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        bound = transform.GetComponent<MeshFilter>().sharedMesh.bounds;
    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

        if (startingGrabType != GrabTypes.None)
        {

            // Call this to continue receiving HandHoverUpdate messages,
            // and prevent the hand from hovering over anything else
            hand.HoverLock(interactable);

            // Attach this object to the hand
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);

        }
        else if (isGrabEnding)
        {
            // Detach this object from the hand
            hand.DetachObject(gameObject);

            // Call this to undo HoverLock
            hand.HoverUnlock(interactable);


        }
    }

    private void Update()
    {
        if (transform.parent == null)
        {
            transform.position = cameraObject.transform.position-(Vector3.up * offset[0] - Vector3.left*offset[1]) ;
        }
        else if (Input.GetKeyDown("p"))
        {
            Vector3 size = Vector3.Scale(materialMenu.GetComponent<RectTransform>().sizeDelta*materialMenu.transform.localScale/ delitel, Vector3.up);
            Instantiate(materialMenu, transform.position+size, GameObject.Find("FallbackObjects").transform.rotation);
        }
     
    }
}
