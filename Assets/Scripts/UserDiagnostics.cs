using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UserDiagnostics : MonoBehaviour
{
    public SteamVR_Action_Boolean LeftHandY;
    public Canvas UserDiagnostic;
    public GameObject hydraulicText;

    private void Start()
    {
        hydraulicText.GetComponent<TextMesh>().text = "random number = " + Random.Range(-20f, 20f) + "\n" + "end";
    }
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
                monki();
            }
        }
    }
    private void monki()
    {
        hydraulicText.GetComponent<TextMesh>().text =
            "Resistance Level = " + Random.Range(-20f, 20f) + "\n" +
            "Water ionization = " + Random.Range(0f, 20f) + "\n" +
            "Last filter replacement =" ;
    }
}
