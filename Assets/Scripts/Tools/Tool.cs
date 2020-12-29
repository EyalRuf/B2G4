using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class Tool : Highlightable, I_InteractableFinder
{
    public Rigidbody rb;
    public Transform originalParent;
    public ToolInteractionRaycast tRaycast;

    public int pickedUpLayer;
    public int interactableLayer;

    public Transform ogTransform;
    public bool isFloatingBackToOriginalPos;
    public float posLerpScale;

    public void Update()
    {
        if (isFloatingBackToOriginalPos)
        {
            transform.rotation = ogTransform.rotation;
            transform.position = Vector3.Lerp(transform.position, ogTransform.position, posLerpScale);

            if (Vector3.Distance(transform.position, ogTransform.position) < 0.1f) {
                transform.position = ogTransform.position;
                isFloatingBackToOriginalPos = false;
                rb.isKinematic = false;
            }
        }
    }

    public Highlightable FindInteractble()
    {
        return tRaycast.PerformRaycast();
    }

    public virtual void Pickup ()
    {
        UnHighlight();
        rb.isKinematic = true;
        tRaycast.gameObject.SetActive(true);
        gameObject.layer = pickedUpLayer;
    }

    public virtual void Putdown ()
    {
        tRaycast.gameObject.SetActive(false);
        transform.parent = originalParent;
        gameObject.layer = interactableLayer;

        isFloatingBackToOriginalPos = true;
    }

    public override void Interact(Tool t)
    {
        Debug.Log("Interacting as a tool");
    }
}
