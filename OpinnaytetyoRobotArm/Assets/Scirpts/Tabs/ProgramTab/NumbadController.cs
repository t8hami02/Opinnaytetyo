using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumbadController : MonoBehaviour
{
    public TMP_InputField numbadInputField;
    public TMP_InputField waitPageInputField;
    public GameObject myNumpad;
    private string myString = "0";
    private bool isThereDot = false;

    public void Update()
    {
        numbadInputField.text = myString;
    }
    public void PressButtonOK()
    {
        if(myString[myString.Length - 1] == '.')
        {
            myString += "0";
            numbadInputField.text += "0";
        }
        waitPageInputField.text = numbadInputField.text;
        numbadInputField.text = "0";
        myNumpad.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void PressButtonX(string add)
    {
        if(myString == "0")
        {
            myString = add;
        }
        else
        {
            myString += add;
        }
    }
    public void PressButtonDot()
    {
        if(isThereDot == false)
        {
            myString += ".";
            isThereDot = true;
        }
    }

    public void SelectWaitInputField()
    {
        Debug.Log("Test selected");
        myNumpad.SetActive(true);
        myString = waitPageInputField.text;
    }

    public void PressDelButton()
    {
        if(myString.Length > 0)
        {
            if(myString[myString.Length - 1] == '.')
            {
                isThereDot = false;
            }
            myString = myString.Remove(myString.Length - 1);
        }
    }
}
