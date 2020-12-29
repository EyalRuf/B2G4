using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UserDiagnostics : MonoBehaviour
{
    public SteamVR_Action_Boolean LeftHandY;

    private void Update()
    {
        if (LeftHandY.stateDown)
        {
            print("Pressed Y");
        }
    }
}
