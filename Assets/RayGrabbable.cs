using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class RayGrabbable : MonoBehaviour
{
    protected Rigidbody rb;
    protected bool isKinematic;
    protected Transform originalParent;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;
    }

    private void OnAttachedToHand(Hand hand)
    {
        rb.isKinematic = true;
        print("holding");
    }
    private void OnDetachedFromHand(Hand hand)
    {
        print("released");
        rb.isKinematic = false;
    }
}
