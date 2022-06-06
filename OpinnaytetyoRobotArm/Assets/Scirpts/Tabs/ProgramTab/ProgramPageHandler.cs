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

    public GameObject panel;
    public int numberOfItemsInPanel = 0;
    private List<GameObject> panelButtonsList = new List<GameObject>();
    public List<GameObject> commandPagesList;

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

    public void pressMoveButton()
    {

        CreateProgramButton("Move");
        CreateProgramButton("Waypoint");

        HideAllCommandPages();
        commandPagesList[0].SetActive(true);

    }

    public void pressWaypointButton()
    {

        CreateProgramButton("Waypoint");

        HideAllCommandPages();
        commandPagesList[1].SetActive(true);

    }

    public void pressWaitButton()
    {

        CreateProgramButton("Wait");

        HideAllCommandPages();
        commandPagesList[2].SetActive(true);

    }

    public void pressSetButton()
    {

        CreateProgramButton("Set");

        HideAllCommandPages();
        commandPagesList[3].SetActive(true);

    }

    public void pressDeleteButton()
    {
        if (panelButtonsList.Count > 0)
        {
            Destroy(panelButtonsList[panelButtonsList.Count - 1]);
            panelButtonsList.RemoveAt(panelButtonsList.Count - 1);
            numberOfItemsInPanel--;
        }

    }

    public void CreateProgramButton(string textContent)
    {
        GameObject button = (GameObject)Instantiate(Resources.Load("myButton"));
        panelButtonsList.Add(button);
        button.transform.SetParent(panel.transform);
        button.transform.localScale = Vector3.one;
        button.transform.localRotation = Quaternion.Euler(Vector3.zero);
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(-panel.GetComponent<RectTransform>().rect.width / 2 + button.GetComponent<RectTransform>().rect.width / 2, panel.GetComponent<RectTransform>().rect.height / 2 - button.GetComponent<RectTransform>().rect.height / 2 - numberOfItemsInPanel * button.GetComponent<RectTransform>().rect.height);
        button.GetComponentInChildren<TextMeshProUGUI>().text = textContent;

        numberOfItemsInPanel++;
    }
}
