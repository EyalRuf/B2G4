using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSystem : MonoBehaviour
{
    public BoltSystem filterBoltSystem;
    public BoltSystem waterBoltSystem;
    public UserDiagnostics UD;

    void Update()
    {
        UD.isFilterGood = filterBoltSystem.IsSystemFunctional();
        UD.isWaterGood = waterBoltSystem.IsSystemFunctional();
        UD.isHydrolicSystemBuilt = filterBoltSystem.IsSystemBuilt() && waterBoltSystem.IsSystemBuilt();
    }
}
