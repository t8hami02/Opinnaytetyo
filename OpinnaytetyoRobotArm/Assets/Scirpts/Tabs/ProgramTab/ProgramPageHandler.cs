using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProgramPageHandler : MonoBehaviour
{
    public GameObject tabButton1;
    public GameObject tabButton2;
    public GameObject tabButton3;

    public GameObject tabContent1;
    public GameObject tabContent2;
    public GameObject tabContent3;

    public GameObject programPage;
    public GameObject movePage;
    public GameObject okButton;
    public GameObject cancelButton;

    public GameObject panel;
    private List<GameObject> panelButtonsList = new List<GameObject>();
    private GameObject lastPressedButton;

    public List<GameObject> commandPagesList;

    private int selectedButtonIndex = 0;

    public void ShowTab1()
    {
        HideAllTabs();
        tabContent1.SetActive(true);
    }

    public void ShowTab2()
    {
        HideAllTabs();
        tabContent2.SetActive(true);
    }
    public void ShowTab3()
    {
        HideAllTabs();
        tabContent3.SetActive(true);
    }

    public void HideAllTabs()
    {

        tabContent1.SetActive(false);
        tabContent2.SetActive(false);
        tabContent3.SetActive(false);

    }

    public void HideAllCommandPages()
    {
        foreach (GameObject page in commandPagesList)
        {
            page.SetActive(false);
        }
    }

    public void ShowCorrectCommandPage(string buttonText)
    {
        HideAllCommandPages();
        if(buttonText == "Move")
        {
            commandPagesList[0].SetActive(true);
        }
        else if (buttonText == "Waypoint")
        {
            commandPagesList[1].SetActive(true);
        }
        else if (buttonText == "Wait")
        {
            commandPagesList[2].SetActive(true);
        }
        else if (buttonText == "Set")
        {
            commandPagesList[3].SetActive(true);
        }

    }

    public void pressMoveButton()
    {

        CreateInstantiatedButton("Move");
        CreateInstantiatedButton("Waypoint");

        HideAllCommandPages();
        commandPagesList[0].SetActive(true);

    }

    public void pressWaypointButton()
    {
        if (DoesGivenButtonTextExists("Move"))
        {
            CreateInstantiatedButton("Waypoint");
        }
        else
        {
            CreateInstantiatedButton("Move");
            CreateInstantiatedButton("Waypoint");
        }

        HideAllCommandPages();
        commandPagesList[1].SetActive(true);
    }

    public void pressWaitButton()
    {

        CreateInstantiatedButton("Wait");

        HideAllCommandPages();
        commandPagesList[2].SetActive(true);

    }

    public void pressSetButton()
    {

        CreateInstantiatedButton("Set");

        HideAllCommandPages();
        commandPagesList[3].SetActive(true);

    }

    public void pressDeleteButton()
    {
        if (panelButtonsList.Count > 0)
        {

            if (!isButtonTextGiven("Move", panelButtonsList[selectedButtonIndex]) && panelButtonsList[selectedButtonIndex].GetComponent<ProgramButtonBoolean>().getBooleanValue() == true)
            {
                GameObject.Find("IKManager").GetComponent<IKManager>().RemoveAtIndex(GetNumberOfNonMoveButtonsBeforeThis());
            }

            Destroy(panelButtonsList[selectedButtonIndex]);
            panelButtonsList.RemoveAt(selectedButtonIndex);

            RearrangeInstantiatedButtons();

            //Select another button as selected
            if (selectedButtonIndex < panelButtonsList.Count)
            {
                PressInstantiatedButton(panelButtonsList[selectedButtonIndex]);
            }
            else if (panelButtonsList.Count > 0)
            {
                selectedButtonIndex = panelButtonsList.Count - 1;
                PressInstantiatedButton(panelButtonsList[selectedButtonIndex]);
            }

        }

    }

    public void pressSetWaypointButton()
    {

        programPage.SetActive(false);
        movePage.SetActive(true);
        okButton.SetActive(true);
        cancelButton.SetActive(true);
    }

    public void pressOKButton()
    {
        if (!panelButtonsList[selectedButtonIndex].GetComponent<ProgramButtonBoolean>().getBooleanValue())
        {
            SavePoint(1);           
            panelButtonsList[selectedButtonIndex].GetComponent<ProgramButtonBoolean>().ChangeBooleanToTrue();
        }
        else
        {
            GameObject.Find("IKManager").GetComponent<IKManager>().EditOrder(GetNumberOfNonMoveButtonsBeforeThis(), 1);
        }
        programPage.SetActive(true);
        movePage.SetActive(false);
        okButton.SetActive(false);
        cancelButton.SetActive(false);
    }

    public void pressCancelButton()
    {
        programPage.SetActive(true);
        movePage.SetActive(false);
        okButton.SetActive(false);
        cancelButton.SetActive(false);
    }

    public bool DoesGivenButtonTextExists( string givenText)
    {

        foreach(GameObject button in panelButtonsList)
        {
            if (button.GetComponentInChildren<TextMeshProUGUI>().text == givenText)
            {
                return true;
            }
        }

        return false;

    }

    public bool isButtonTextGiven(string givenText, GameObject button)
    {
        if (button.GetComponentInChildren<TextMeshProUGUI>().text == givenText)
        {
            return true;
        }
        return false;
    }

    public bool IsLastButtonTextWaypoint()
    {
        if (panelButtonsList.Count > 0)
        {
            if(panelButtonsList[panelButtonsList.Count - 1].GetComponentInChildren<TextMeshProUGUI>().text == "Waypoint")
            {
                return true;
            }
        }

        return false;

    }

    public void CreateInstantiatedButton(string textContent)
    {
        // Instantiate a new button on program page's robot program tree and add it to panelbuttonlist.
        // Also define the new buttons features
        GameObject button = (GameObject)Instantiate(Resources.Load("myButton"));
        if(panelButtonsList.Count <= 0)
        {
            panelButtonsList.Add(button);
        }
        else
        {
            panelButtonsList.Insert(selectedButtonIndex + 1, button);

        }
        button.transform.SetParent(panel.transform);
        button.transform.localScale = Vector3.one;
        button.transform.localRotation = Quaternion.Euler(Vector3.zero);
        button.transform.localPosition = Vector3.zero;
        RearrangeInstantiatedButtons();
        button.GetComponentInChildren<TextMeshProUGUI>().text = textContent;
        button.GetComponent<Button>().onClick.AddListener(() => { PressInstantiatedButton(button); });

        //Select the instantiated button
        if(panelButtonsList.Count > 1)
        {
            PressInstantiatedButton(panelButtonsList[selectedButtonIndex + 1]);
        }
        else
        {
            PressInstantiatedButton(panelButtonsList[selectedButtonIndex]);
        }

    }

    public void SavePoint(int type)
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().AddNewOrder(GetNumberOfNonMoveButtonsBeforeThis(), type);
    }

    public void PressInstantiatedButton(GameObject button = null)
    {
        if(lastPressedButton != null)
        {
            if (panelButtonsList[selectedButtonIndex].GetComponent<ProgramButtonBoolean>().getBooleanValue())
            {
                lastPressedButton.GetComponent<Image>().color = Color.white;
            }
            else
            {
                lastPressedButton.GetComponent<Image>().color = Color.yellow;
            }
        }

        button.GetComponent<Image>().color = Color.gray;

        selectedButtonIndex = panelButtonsList.IndexOf(button);
        Debug.Log(selectedButtonIndex);

        ShowCorrectCommandPage(button.GetComponentInChildren<TextMeshProUGUI>().text);
        lastPressedButton = button;
    }

    public void RearrangeInstantiatedButtons()
    {
        for(int i = 0; i < panelButtonsList.Count; i++)
        {
            panelButtonsList[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(-panel.GetComponent<RectTransform>().rect.width / 2 + panelButtonsList[i].GetComponent<RectTransform>().rect.width / 2, panel.GetComponent<RectTransform>().rect.height / 2 - panelButtonsList[i].GetComponent<RectTransform>().rect.height / 2 - i * panelButtonsList[i].GetComponent<RectTransform>().rect.height,0);
        }
    }

    public int GetNumberOfNonMoveButtonsBeforeThis()
    {
        int waypoints = 0;

        for(int i = 0; i < selectedButtonIndex; i++)
        {
            if (!isButtonTextGiven("Move", panelButtonsList[i]))
            {
                waypoints++;
            }
        }

        return waypoints;
    }

    public void PressStartProgramButton()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().MoveBetweenPointsSwitch();
    }

    public void PressAddWaitButton()
    {
        if (!panelButtonsList[selectedButtonIndex].GetComponent<ProgramButtonBoolean>().getBooleanValue())
        {
            SavePoint(2);
            panelButtonsList[selectedButtonIndex].GetComponent<ProgramButtonBoolean>().ChangeBooleanToTrue();
        }        
    }

    public void PressAddSetButton()
    {
        if (!panelButtonsList[selectedButtonIndex].GetComponent<ProgramButtonBoolean>().getBooleanValue())
        {
            SavePoint(3);
            panelButtonsList[selectedButtonIndex].GetComponent<ProgramButtonBoolean>().ChangeBooleanToTrue();
        }       
    }

}
