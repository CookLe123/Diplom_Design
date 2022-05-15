using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Interactable_Furniture : MonoBehaviour
{
    private Interactable interactable;

    GameObject uiObject;

    GameObject rotationObject;

    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        uiObject = transform.parent.Find("Ui_elements").gameObject;
        rotationObject = transform.parent.Find("Ui_elements").gameObject;
    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

        if (startingGrabType != GrabTypes.None)
        {
            SetOffUI();

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

            SetActiveUi();

        }
    }

    private void SetOffUI()
    {
        uiObject.SetActive(false);
        rotationObject.SetActive(false);
    }

    private void SetActiveUi()
    {
        uiObject.SetActive(true);
        rotationObject.SetActive(true);
    }

}
