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

    public Highlightable FindInteractable()
    {
        return tRaycast.PerformRaycast();
    }

    public override void OnAttachedToHand(Hand hand)
    {
        base.OnAttachedToHand(hand);

        tRaycast.gameObject.SetActive(true);
    }

    public override void OnDetachedFromHand(Hand hand)
    {
        base.OnDetachedFromHand(hand);

        tRaycast.gameObject.SetActive(false);
        isFloatingBackToOriginalPos = true;
    }
}
