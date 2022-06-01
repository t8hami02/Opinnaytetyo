using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btnTemplates;

    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject btn5;
    public GameObject btn6;
    public GameObject btn7;
    public GameObject btn8;
    public GameObject btn9;
    public GameObject btn10;
    public GameObject btn11;


    public void pressAdvancedButton() 
    {
        showAdvancedSubButtons();
        GameObject.Find("BtnBasic").GetComponent<BasicButtonHandler>().hideBasicSubButtons();
        transform.position = new Vector3(0,-50,0);
        btnTemplates.transform.position = new Vector3(0, -650, 0);

    }
    public void hideAdvancedSubButtons()
    {
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
        btn4.SetActive(false);
        btn5.SetActive(false);
        btn6.SetActive(false);
        btn7.SetActive(false);
        btn8.SetActive(false);
        btn9.SetActive(false);
        btn10.SetActive(false);
        btn11.SetActive(false);
    }

    public void showAdvancedSubButtons()
    {
        btn1.SetActive(true);
        btn2.SetActive(true);
        btn3.SetActive(true);
        btn4.SetActive(true);
        btn5.SetActive(true);
        btn6.SetActive(true);
        btn7.SetActive(true);
        btn8.SetActive(true);
        btn9.SetActive(true);
        btn10.SetActive(true);
        btn11.SetActive(true);

    }
}
