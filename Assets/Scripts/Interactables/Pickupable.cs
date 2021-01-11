using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(VelocityEstimator))]
public class Pickupable : Highlightable
{
    public Rigidbody rb;
    public Transform originalParent;
    public bool isLockedInPlace;
    public bool isBeingHeld;

    public int pickedUpLayer;
    public int interactableLayer;

    private VelocityEstimator estimator;
    private Vector3 velocity;
    private Vector3 angularVelocity;

    private void Awake()
    {
        estimator = GetComponent<VelocityEstimator>();
    }
    public virtual void Pickup()
    {
        UnHighlight();
        rb.isKinematic = true;
        gameObject.layer = pickedUpLayer;
        isBeingHeld = true;
    }

    public virtual void Putdown()
    {
        transform.parent = originalParent;
        rb.isKinematic = false;
        gameObject.layer = interactableLayer;
        isBeingHeld = false;
    }

    public override void Interact(Tool t)
    {
        Debug.Log("Interacting as a pickupable");
    }

    protected virtual void OnAttachedToHand(Hand hand)
    {
        estimator.BeginEstimatingVelocity();
    }

    protected virtual void OnDetachedFromHand(Hand hand)
    {
        estimator.FinishEstimatingVelocity();
        velocity = estimator.GetVelocityEstimate();
        angularVelocity = estimator.GetAngularVelocityEstimate();
        print(velocity);
        print(angularVelocity);
        GetComponent<Rigidbody>().AddForce(velocity * 100, ForceMode.Acceleration);
        GetComponent<Rigidbody>().angularVelocity = angularVelocity;

    }
}
