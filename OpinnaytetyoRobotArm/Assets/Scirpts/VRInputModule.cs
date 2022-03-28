using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

// Not in use, will be removed later

public class VRInputModule : BaseInputModule
{
    public Camera myCamera;
    public SteamVR_Input_Sources myTargetSource;
    public SteamVR_Action_Boolean myClickAction;

    private GameObject currentObject = null;
    private PointerEventData myData = null;

    protected override void Awake()
    {
        base.Awake();

        myData = new PointerEventData(eventSystem);
    }

    public override void Process()
    {
        // Reset data, set camera
        myData.Reset();
        myData.position = new Vector2(myCamera.pixelWidth / 2, myCamera.pixelHeight / 2);

        // Raycast
        eventSystem.RaycastAll(myData, m_RaycastResultCache);
        myData.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        currentObject = myData.pointerCurrentRaycast.gameObject;

        // Clear
        m_RaycastResultCache.Clear();

        // Hover
        HandlePointerExitAndEnter(myData, currentObject);

        // Press
        if (myClickAction.GetStateDown(myTargetSource))
            ProcessPress(myData);

        // Release
        if (myClickAction.GetStateUp(myTargetSource))
            ProcessRelease(myData);
    }

    public PointerEventData GetData()
    {
        return myData;
    }

    private void ProcessPress(PointerEventData data)
    {
        // Set raycast
        data.pointerPressRaycast = data.pointerCurrentRaycast;

        // Check for object hit, get the downd handler, call
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(currentObject, data, ExecuteEvents.pointerDownHandler);

        // If no down hanlder, try and get click handler
        if (newPointerPress == null)
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);

        // Set data
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = currentObject;
    }

    private void ProcessRelease(PointerEventData data)
    {
        // Execute pointer up
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

        // Check for click handler
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);

        // Check if actual
        if(data.pointerPress == pointerUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        // Clear selected gameobject
        eventSystem.SetSelectedGameObject(null);

        // Reset data
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }
}
