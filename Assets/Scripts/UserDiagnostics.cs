using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UserDiagnostics : MonoBehaviour
{
    public SteamVR_Action_Boolean LeftHandY;
    public Canvas UserDiagnostic;

    private void Update()
    {
        if (LeftHandY.stateDown)
        {
            if (UserDiagnostic.enabled)
            {
                UserDiagnostic.enabled = false;
            }
            else
            {
                UserDiagnostic.enabled = true;
            }
        }
    }
}
