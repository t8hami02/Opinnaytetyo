using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicButtonHandler : MonoBehaviour
{
    public GameObject btnAdvanced;
    public GameObject btnTemplates;
    public GameObject canvas;

    public List<GameObject> buttonsList;


    public void pressBasicButton() 
    {
        showBasicSubButtons();
        GameObject.Find("BtnAdvanced").GetComponent<AdvancedButtonHandler>().hideAdvancedSubButtons();
        GameObject.Find("BtnTemplates").GetComponent<TemplatesButtonHandler>().hideTemplatesSubButtons();
        btnAdvanced.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -500, 0);
        btnTemplates.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -550, 0);

        Debug.Log("Basic Button pressed");

    }
    public void hideBasicSubButtons()
    {
        foreach (GameObject button in buttonsList)
        {
            button.SetActive(false);
        }

    }

    public void showBasicSubButtons()
    {
        foreach(GameObject button in buttonsList)
        {
            button.SetActive(true);
        }

    }
}
