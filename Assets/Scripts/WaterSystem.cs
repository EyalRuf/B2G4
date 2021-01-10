using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSystem : MonoBehaviour
{
    public BoltSystem filterBoltSystem;
    public BoltSystem waterBoltSystem;

    public MeshRenderer wsMachineMR;
    public Material functionalMat;
    public Material notFunctionalMat;

    // Update is called once per frame
    void Update()
    {
        if (filterBoltSystem.IsSystemFunctional() && waterBoltSystem.IsSystemFunctional())
        {
            wsMachineMR.material = functionalMat;
        } else
        {
            wsMachineMR.material = notFunctionalMat;
        }
    }
}
