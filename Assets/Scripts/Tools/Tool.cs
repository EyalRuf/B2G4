using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class Tool : Pickupable, I_InteractableFinder
{
    public ToolInteractionRaycast tRaycast;

    public Transform ogTransform;
    public bool isFloatingBackToOriginalPos;
    public float posLerpScale;

    public void Update()
    {
        if (isFloatingBackToOriginalPos)
        {
            transform.rotation = ogTransform.rotation;
            transform.position = Vector3.Lerp(transform.position, ogTransform.position, posLerpScale);

            if (Vector3.Distance(transform.position, ogTransform.position) < 0.1f)
            {
                transform.position = ogTransform.position;
                isFloatingBackToOriginalPos = false;
                rb.isKinematic = false;
            }
        }
    }

    public Highlightable FindInteractable()
    {
        return tRaycast.PerformRaycast();
    }

    public override void Pickup ()
    {
        base.Pickup();
        tRaycast.gameObject.SetActive(true);
    }

    public override void Putdown ()
    {
        base.Putdown();
        tRaycast.gameObject.SetActive(false);
        isFloatingBackToOriginalPos = true;
    }
}
