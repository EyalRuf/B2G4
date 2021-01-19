﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSystem : MonoBehaviour
{
    public BoltSystem filterBoltSystem;
    public BoltSystem waterBoltSystem;

    public bool isHydrolicSystemBuilt;
    public bool isFilterGood;
    public bool isWaterGood;

    public string ionizationNumLow;
    public string ionizationNumHigh;

    void Update()
    {
        isFilterGood = filterBoltSystem.IsSystemFunctional();
        isWaterGood = waterBoltSystem.IsSystemFunctional();
        isHydrolicSystemBuilt = filterBoltSystem.IsSystemBuilt() && waterBoltSystem.IsSystemBuilt();

        if (isFilterGood && isWaterGood)
        {
            //yay
        }
    }
}
