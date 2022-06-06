using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonHandler : MonoBehaviour
{
    public GameObject panel;
    public Canvas canvas;

   public void pressMoveButton()
    {
        var button = (GameObject)Instantiate(Resources.Load("myButton", typeof(GameObject))) as GameObject;
        button.transform.SetParent(panel.transform);
        button.transform.localScale = Vector3.one;
        button.transform.localRotation = Quaternion.Euler(Vector3.zero);
        button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);

    }
}
