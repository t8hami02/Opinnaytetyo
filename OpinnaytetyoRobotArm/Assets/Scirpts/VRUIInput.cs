using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

[RequireComponent(typeof(SteamVR_LaserPointer))]
public class VRUIInput : MonoBehaviour
{
    private SteamVR_LaserPointer laserPointer;
    //private SteamVR_TrackedController trackedController;

    private void OnEnable()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn -= HandlePointerIn;
        laserPointer.PointerIn += HandlePointerIn;
        laserPointer.PointerOut -= HandlePointerOut;
        laserPointer.PointerOut += HandlePointerOut;
        laserPointer.PointerClick += HandleTriggerClicked;

    }

    private void HandleTriggerClicked(object sender, PointerEventArgs e)
    {
        //if (EventSystem.current.currentSelectedGameObject != null)
        //{
        //    ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
        //}
        IPointerClickHandler clickHandler = e.target.GetComponent<IPointerClickHandler>();
        if (clickHandler == null)
        {
            return;
        }


        clickHandler.OnPointerClick(new PointerEventData(EventSystem.current));

    }

    private void HandlePointerIn(object sender, PointerEventArgs e)
    {
        //var button = e.target.GetComponent<Button>();
        //if (button != null)
        //{
        //    button.Select();
        //    //Debug.Log("HandlePointerIn", e.target.gameObject);
        //}
        IPointerEnterHandler pointerEnterHandler = e.target.GetComponent<IPointerEnterHandler>();
        if (pointerEnterHandler == null)
        {
            return;
        }

        pointerEnterHandler.OnPointerEnter(new PointerEventData(EventSystem.current));

    }

    private void HandlePointerOut(object sender, PointerEventArgs e)
    {

        //var button = e.target.GetComponent<Button>();
        //if (button != null)
        //{
        //    EventSystem.current.SetSelectedGameObject(null);
        //    //Debug.Log("HandlePointerOut", e.target.gameObject);
        //}

        IPointerExitHandler pointerExitHandler = e.target.GetComponent<IPointerExitHandler>();
        if (pointerExitHandler == null)
        {
            return;
        }

        pointerExitHandler.OnPointerExit(new PointerEventData(EventSystem.current));
    }
}