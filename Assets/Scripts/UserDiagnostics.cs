using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UserDiagnostics : MonoBehaviour
{
    public SteamVR_Action_Boolean LeftHandY;
    public GameObject diaInterface;
    public GameObject hydraulicText;

    public bool isHydrolicSystemBuilt;
    public bool isFilterGood;
    public bool isWaterGood;

    public string ionizationNumLow;
    public string ionizationNumHigh;

    private void Update()
    {
        if (LeftHandY.stateDown)
        {
            diaInterface.SetActive(!diaInterface.activeSelf);
        }

        hydraulicText.GetComponent<TextMesh>().text =
            !isHydrolicSystemBuilt ? "Hydrolic system is missing components. \n Please attach them and try again." : (
            "Resistance Level - " + (isFilterGood && isWaterGood ? "High" : "Low") + "\n" +
            "Water ionization - " + (isWaterGood ? ionizationNumHigh : ionizationNumLow) + "\n" +
            "Last filter replacement - " + (isFilterGood ? "25/01/2021" : "20/09/1995"));
    }
}

