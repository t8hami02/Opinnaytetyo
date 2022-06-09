using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedButtonHandler : MonoBehaviour
{
    public GameObject btnTemplates;

    public List<GameObject> buttonsList;


    public void pressAdvancedButton() 
    {
        showAdvancedSubButtons();
        GameObject.Find("BtnBasic").GetComponent<BasicButtonHandler>().hideBasicSubButtons();
        GameObject.Find("BtnTemplates").GetComponent<TemplatesButtonHandler>().hideTemplatesSubButtons();
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50, 0);
        btnTemplates.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -650, 0);


    }
    public void hideAdvancedSubButtons()
    {
        foreach (GameObject button in buttonsList)
        {
            button.SetActive(false);
        }

    }

    public void showAdvancedSubButtons()
    {
        foreach (GameObject button in buttonsList)
        {
            button.SetActive(true);
        }
    }
}
