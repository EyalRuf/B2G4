using UnityEngine;
using System.Collections;

public class Pickupable : Highlightable
{
    public Rigidbody rb;
    public Transform originalParent;
    public bool isLockedInPlace;

    public int pickedUpLayer;
    public int interactableLayer;

    public virtual void Pickup()
    {
        UnHighlight();
        rb.isKinematic = true;
        gameObject.layer = pickedUpLayer;
    }

    public virtual void Putdown()
    {
        transform.parent = originalParent;
        gameObject.layer = interactableLayer;
    }

    public override void Interact(Tool t)
    {
        Debug.Log("Interacting as a pickupable");
    }
}
