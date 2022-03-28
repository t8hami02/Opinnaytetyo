using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Not in use, will be removed later

public class Pointer : MonoBehaviour
{
    public float defaultLenght = 5.0f;
    public GameObject myDot;
    public VRInputModule myInputModule;

    private LineRenderer myLinerRender = null;

    public void Awake()
    {
        myLinerRender = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // Use default or distance
        PointerEventData data = myInputModule.GetData();
        float targetLenght = data.pointerCurrentRaycast.distance == 0 ? defaultLenght : data.pointerCurrentRaycast.distance;

        // Raycast
        RaycastHit hit = CreateRaycast(targetLenght);

        // Default
        Vector3 endPosition = transform.position + (transform.forward * targetLenght);

        // Or based on hit
        if (hit.collider != null)
            endPosition = hit.point;

        // Set position of the dot
        myDot.transform.position = endPosition;

        // Set linerenderer
        myLinerRender.SetPosition(0, transform.position);
        myLinerRender.SetPosition(1, endPosition);

    }

    private RaycastHit CreateRaycast(float lenght)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLenght);

        return hit;
    }
}
