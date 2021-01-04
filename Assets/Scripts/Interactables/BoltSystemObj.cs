using UnityEngine;
using System.Collections;

public class BoltSystemObj : Pickupable
{
    public BoltSystem bSystem;
    public MeshRenderer mr;
    public bool isObjectFunctional;

    // Update is called once per frame
    void Update()
    {
        // Player holding it && system is missing a filter
        if (isBeingHeld && bSystem.attachedObj == null) 
        {
            // Only if in range 
            if (Vector3.Distance(transform.position, bSystem.anchorTransform.position) <= bSystem.anchoringDistance)
            {
                mr.enabled = false;
                bSystem.ObjectHovering();
            } else
            {
                mr.enabled = true;
                bSystem.ObjectNoLongerHovering();
            }
        }
    }

    public override void Pickup()
    {
        base.Pickup();
        if (bSystem.attachedObj != null && GetInstanceID() == bSystem.attachedObj.GetInstanceID())
        {
            bSystem.DetachObj();
        }
    }

    public override void Putdown()
    {
        base.Putdown();

        // Only if in range & system doesn't have another filter connected already
        if (bSystem.attachedObj == null && Vector3.Distance(transform.position, bSystem.anchorTransform.position) <= bSystem.anchoringDistance)
        {
            transform.parent = bSystem.transform;
            transform.position = bSystem.anchorTransform.position;
            transform.rotation = bSystem.anchorTransform.rotation;
            rb.isKinematic = true;
            bSystem.AttachObj(this);
        }
    }
}
