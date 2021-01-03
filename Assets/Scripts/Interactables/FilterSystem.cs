using UnityEngine;
using System.Collections;

public class FilterSystem : MonoBehaviour
{
    public Pickupable filterPU;
    public Transform puAnchorPoint;
    public Bolt bolt;

    public GameObject filterPlaceholder;

    public void UseBolt(bool isClosed)
    {
        filterPU.isLockedInPlace = !isClosed;
    }

    public void DetachFilter ()
    {
        filterPU = null;
        bolt.canBolt = false;
        filterPlaceholder.SetActive(true);
    }

    public void AttachFilter(Pickupable filter)
    {
        filterPU = filter;
        bolt.canBolt = true;
        filterPlaceholder.SetActive(false);
    }

    void Update()
    {
        // If filter is not connected and I'm holding one close to the anchor point
        // => Snap it to anchor

        if (filterPU == null)
        {

        }
    }
}
