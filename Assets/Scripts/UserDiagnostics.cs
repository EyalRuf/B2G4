using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR;

public class UserDiagnostics : MonoBehaviour
{
    public SteamVR_Action_Boolean LeftHandY;
    public GameObject diaInterface;
    public TextMeshProUGUI hydraulicText;

    public WaterSystem WS;

    private void Update()
    {
        if (LeftHandY.stateDown)
        {
            diaInterface.SetActive(!diaInterface.activeSelf);
        }

        hydraulicText.text =
            !WS.isHydrolicSystemBuilt ? "Hydrolic system is missing components. \n Please attach them and try again." : (
            "Resistance Level - " + (WS.isFilterGood && WS.isWaterGood ? "High" : "Low") + "\n" +
            "Water ionization - " + (WS.isWaterGood ? WS.ionizationNumHigh : WS.ionizationNumLow) + "\n" +
            "Last filter replacement - " + (WS.isFilterGood ? "25/01/2021" : "20/09/1995"));
    }
}

