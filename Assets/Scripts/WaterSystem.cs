using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSystem : MonoBehaviour
{
    public Bolt boltToFilter;
    public Bolt boltToWater;

    public Pickupable filter;
    public Pickupable waterCannister;

    public bool isFilterLockedInPlace;
    public bool isWaterCannisterLockedInPlace;

    public Transform filterAnchor;
    public Transform waterCannisterAnchor;
    public float attachmentDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnboltFilterBolt ()
    {

    }
}
