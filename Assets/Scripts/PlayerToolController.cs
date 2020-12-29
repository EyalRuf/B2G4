using UnityEngine;
using System.Collections;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerToolController : MonoBehaviour
{
    public Tool heldTool; // The tool that you're currently holding 
    public EmptyHands emptyHandsTool;
    public bool isHoldingTool;
    public Highlightable hoveredObj; // Interactable object you're currently looking at

    public SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Boolean grip;

    public Hand hand;
    public Transform toolAttachPoint;

    // Update is called once per frame
    void Update()
    {
        I_InteractableFinder currIF = emptyHandsTool;
        if (isHoldingTool)
        {
            currIF = heldTool;
        }

        FindToolInteractables(currIF);

        // Interact btn pressed & we're looking at an interactable
        if (trigger.stateDown && hoveredObj != null)
        {
            if (!isHoldingTool) // I am not holding a tool
            {
                    // Is this hovered object a tool
                    if (hoveredObj.GetType() == typeof(Tool))
                    {
                        PickUpTool((Tool) hoveredObj);
                    } else // Looking at a non-tool
                    {
                        InteractWithHoveredObj(hoveredObj, null);
                    }
            } else
            {
                InteractWithHoveredObj(hoveredObj, heldTool);
            }
        }

        // Pick up / Put down btn presed
        if (grip.stateDown)
        {
            if (isHoldingTool)
            {
                DropDownTool();
            // Not holding a tool and i'm hovering over a tool
            } else if (hoveredObj != null && hoveredObj.GetType() == typeof(Tool)) 
            {
                PickUpTool((Tool)hoveredObj);
            } 
        }
    }

    void FindToolInteractables(I_InteractableFinder iFinder)
    {
        hoveredObj = iFinder.FindInteractble();
    }

    void PickUpTool (Tool t)
    {
        emptyHandsTool.DeactivateHands(); // Deactivate empty hands tool

        // Pick up, attach, and activate new tool
        heldTool = t;
        heldTool.transform.position = toolAttachPoint.position;
        heldTool.transform.rotation = toolAttachPoint.rotation;
        hand.AttachObject(heldTool.gameObject, GrabTypes.Grip, Hand.AttachmentFlags.ParentToHand);
        heldTool.Pickup();

        isHoldingTool = true;
    }

    void DropDownTool ()
    {
        // Detach, put down and deactivate old tool
        heldTool.Putdown();
        hand.DetachObject(heldTool.gameObject);

        heldTool = null;
        isHoldingTool = false;

        // Activate hands again
        emptyHandsTool.ActivateHands();
    }

    void InteractWithHoveredObj (Highlightable hoveredObj, Tool toolUsed)
    {
        hoveredObj.Interact(toolUsed);
    }
}
