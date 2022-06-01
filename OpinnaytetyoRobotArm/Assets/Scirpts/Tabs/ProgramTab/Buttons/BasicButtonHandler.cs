using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonHandler : MonoBehaviour
{
    public GameObject btnAdvanced;
    public GameObject btnTemplates;

    public List<GameObject> buttonsList;

    //public GameObject btn1;
    //public GameObject btn2;
    //public GameObject btn3;
    //public GameObject btn4;
    //public GameObject btn5;
    //public GameObject btn6;
    //public GameObject btn7;
    //public GameObject btn8;
    //public GameObject btn9;


    public void pressBasicButton() 
    {
        showBasicSubButtons();
        GameObject.Find("BtnAdvanced").GetComponent<AdvancedButtonHandler>().hideAdvancedSubButtons();
        btnAdvanced.transform.position = new Vector3(0,-500,0);
        btnTemplates.transform.position = new Vector3(0, -550, 0);
        Debug.Log("Basic Button pressed");

    }
    public void hideBasicSubButtons()
    {
        foreach (GameObject button in buttonsList)
        {
            button.SetActive(false);
        }

        //btn1.SetActive(false);
        //btn2.SetActive(false);
        //btn3.SetActive(false);
        //btn4.SetActive(false);
        //btn5.SetActive(false);
        //btn6.SetActive(false);
        //btn7.SetActive(false);
        //btn8.SetActive(false);
        //btn9.SetActive(false);
    }

    public void showBasicSubButtons()
    {
        foreach(GameObject button in buttonsList)
        {
            button.SetActive(true);
        }

        //btn1.SetActive(true);
        //btn2.SetActive(true);
        //btn3.SetActive(true);
        //btn4.SetActive(true);
        //btn5.SetActive(true);
        //btn6.SetActive(true);
        //btn7.SetActive(true);
        //btn8.SetActive(true);
        //btn9.SetActive(true);
    }
}
