using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInput : MonoBehaviour
{
    public GameObject canvasMenu;
    private bool isMenuActive = false;

    private void Start()
    {
        SteamVR_Actions.default_GrabGrip.AddOnStateDownListener(TriggerPressed, SteamVR_Input_Sources.Any);

    }

    private void TriggerPressed(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if(isMenuActive == true)
        { 
            canvasMenu.SetActive(false);
            isMenuActive = false;
        }
        else
        {
            canvasMenu.SetActive(true);
            isMenuActive = true;

        }
        //Debug.Log("Grab trigger");
    }
}
