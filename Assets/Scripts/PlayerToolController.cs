using UnityEngine;
using System.Collections;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerToolController : MonoBehaviour
{
    //public Tool heldTool; // The tool that you're currently holding 
    public Pickupable heldObj;
    public EmptyHands emptyHandsTool;
    public bool isHoldingObj;
    public Highlightable hoveredObj; // Interactable object you're currently looking at

    public SteamVR_Action_Boolean interactBtn;
    public SteamVR_Action_Boolean pickUpBtn;

    public Hand hand;
    public Transform toolAttachPoint;

    void Update()
    {
        bool isHeldObjATool = heldObj != null && (heldObj.GetType() == typeof(Tool));

        I_InteractableFinder currIF = emptyHandsTool;
        if (isHoldingObj)
        {
            currIF = null;
            if (isHeldObjATool)
            {
                currIF = (Tool)heldObj;
            }
        }
        FindToolInteractables(currIF);

        if (!isHoldingObj || isHeldObjATool)
        {
            // Interact btn pressed & we're looking at an interactable
            if (trigger.stateDown && hoveredObj != null)
            {
                if (!isHoldingObj) // I am not holding a tool
                {
                        // Is this hovered object a pickupable
                        if (hoveredObj.GetType() == typeof(Pickupable))
                        {
                            PickUpObj((Pickupable)hoveredObj);
                        } else // Looking at a non-tool
                        {
                            InteractWithHoveredObj(hoveredObj, null);
                        }
                } else
                {
                    InteractWithHoveredObj(hoveredObj, (Tool)heldObj);
                }
            }
        }

        // Pick up / Put down btn presed
        if (pickUpBtn.stateDown)
        {
            if (isHoldingObj)
            {
                DropDownObj();
            // Not holding a tool and i'm hovering over a tool
            } else if (hoveredObj != null && (hoveredObj.GetType() == typeof(Pickupable) || hoveredObj.GetType() == typeof(Tool))) 
            {
                PickUpObj((Pickupable)hoveredObj);
            } 
        }
    }

    void FindToolInteractables(I_InteractableFinder iFinder)
    {
        if (iFinder != null)
            hoveredObj = iFinder.FindInteractble();
        else
            hoveredObj = null;
    }

    void PickUpObj (Pickupable pu)
    {
        if (pu.isLockedInPlace)
        {
            // Show some indication that it is locked
        } else
        {
            emptyHandsTool.DeactivateHands(); // Deactivate empty hands tool

            // Pick up, attach, and activate new tool
            heldObj = pu;
            heldObj.transform.position = toolAttachPoint.position;
            heldObj.transform.rotation = toolAttachPoint.rotation;
            hand.AttachObject(heldObj.gameObject, GrabTypes.Grip, Hand.AttachmentFlags.ParentToHand);
            heldObj.Pickup();

            isHoldingObj = true;
        }
    }

    void DropDownObj ()
    {
        // Detach, put down and deactivate old tool
        heldObj.Putdown();
        hand.DetachObject(heldObj.gameObject);

        heldObj = null;
        isHoldingObj = false;

        // Activate hands again
        emptyHandsTool.ActivateHands();
    }

    void InteractWithHoveredObj(Highlightable hoveredObj, Tool toolUsed)
    {
        hoveredObj.Interact(toolUsed);
    }
}
