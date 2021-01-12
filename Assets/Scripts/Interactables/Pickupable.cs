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

    public override void Interact(Tool t)
    {
        Debug.Log("Interacting as a pickupable");
    }

    public virtual void OnAttachedToHand(Hand hand)
    {
        UnHighlight();
        rb.isKinematic = true;
        gameObject.layer = pickedUpLayer;
        isBeingHeld = true;

        //Throwable
        estimator.BeginEstimatingVelocity();
    }

    public virtual void OnDetachedFromHand(Hand hand)
    {
        transform.parent = originalParent;
        rb.isKinematic = false;
        gameObject.layer = interactableLayer;
        isBeingHeld = false;

        // Throwable
        estimator.FinishEstimatingVelocity();
        velocity = estimator.GetVelocityEstimate();
        angularVelocity = estimator.GetAngularVelocityEstimate();
        GetComponent<Rigidbody>().AddForce(velocity * 100, ForceMode.Acceleration);
        GetComponent<Rigidbody>().angularVelocity = angularVelocity;

    }
}
