using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplatesButtonHandler : MonoBehaviour
{
    public GameObject btnAdvanced;

    public List<GameObject> buttonsList;


    public void pressTemplatesButton()
    {
        showTemplateSubButtons();
        GameObject.Find("BtnBasic").GetComponent<BasicButtonHandler>().hideBasicSubButtons();
        GameObject.Find("BtnAdvanced").GetComponent<AdvancedButtonHandler>().hideAdvancedSubButtons();
        btnAdvanced.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50, 0);
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -100, 0);



    }
    public void hideTemplatesSubButtons()
    {
        foreach (GameObject button in buttonsList)
        {
            button.SetActive(false);
        }

    }

    public void showTemplateSubButtons()
    {
        foreach (GameObject button in buttonsList)
        {
            button.SetActive(true);
        }
    }
}
