using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedButtonHandler : MonoBehaviour
{
    public GameObject btnBasic;
    public GameObject btnTemplates;

    public List<GameObject> buttonsList;


    public void pressAdvancedButton() 
    {
        showAdvancedSubButtons();
        GameObject.Find("BtnBasic").GetComponent<BasicButtonHandler>().hideBasicSubButtons();
        GameObject.Find("BtnTemplates").GetComponent<TemplatesButtonHandler>().hideTemplatesSubButtons();
        transform.position = btnBasic.transform.position + new Vector3(0,-50,0);
        btnTemplates.transform.position = buttonsList[buttonsList.Count - 1].transform.position + new Vector3(-160, -25, 0);

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
