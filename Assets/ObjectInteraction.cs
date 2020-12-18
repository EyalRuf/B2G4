using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

// https://answers.unity.com/questions/1693142/steamvr-20-how-to-implement-distance-grab.html

public class ObjectInteraction : MonoBehaviour
{
    public LayerMask InteractableLayer; // Interactable items

    public SteamVR_Action_Boolean input;
    Hand hand;
    bool isAttached = false; // do we have something in our hand?
    GameObject attachedObject = null; // what do we have in our hand
    GameObject previousInteractable;

    void Awake()
    {
        hand = GetComponent<Hand>();
    }

    public void Interact(Interactable interactable)
    {
        SteamVR_Input_Sources source = hand.handType;
        if (interactable != null)
        {
            if (!isAttached)
            {
                if (interactable.CompareTag("Tool"))
                {
                    // Move to hand
                    interactable.transform.LookAt(transform);
                    interactable.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 500, ForceMode.Force);
                    attachedObject = interactable.gameObject;
                    isAttached = true;
                }
            }
        }
        else if (isAttached && interactable)
        {
            hand.DetachObject(attachedObject, true);
            attachedObject = null;
            isAttached = false;
        }

    }

    private void LateUpdate()
    {
        if (isAttached)
        {
            hand.AttachObject(attachedObject, GrabTypes.Grip);
        }
    }
}