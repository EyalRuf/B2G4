using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UserDiagnostics : MonoBehaviour
{
    public SteamVR_Action_Boolean LeftHandY;
    public GameObject diaInterface;
    public GameObject hydraulicText;

    private void Update()
    {
        if (LeftHandY.stateDown)
        {
            diaInterface.SetActive(!diaInterface.activeSelf);
/*
            if (hydraulicText.activeSelf)
            {
                monki();
            }*/
        }
    }

    public void monki()
    {
        hydraulicText.GetComponent<TextMesh>().text =
            "Resistance Level = " + Random.Range(-20f, 20f) + "\n" +
            "Water ionization = " + Random.Range(0f, 20f) + "\n" +
            "Last filter replacement =";
    }
}

