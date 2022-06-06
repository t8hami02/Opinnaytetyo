using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicButtonHandler : MonoBehaviour
{
    public GameObject btnAdvanced;
    public GameObject btnTemplates;

    public List<GameObject> buttonsList;


    public void pressBasicButton() 
    {
        showBasicSubButtons();
        GameObject.Find("BtnAdvanced").GetComponent<AdvancedButtonHandler>().hideAdvancedSubButtons();
        GameObject.Find("BtnTemplates").GetComponent<TemplatesButtonHandler>().hideTemplatesSubButtons();
        btnAdvanced.transform.position = buttonsList[buttonsList.Count-1].transform.position + new Vector3(-160, -25, 0);
        btnTemplates.transform.position = btnAdvanced.transform.position + new Vector3(0, -50, 0);
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
