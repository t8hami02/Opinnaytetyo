using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsHandler : MonoBehaviour
{

    public GameObject tabButton1;
    public GameObject tabButton2;
    public GameObject tabButton3;
    public GameObject tabButton4;
    public GameObject tabButton5;
    public GameObject tabButton6;

    public GameObject tabContent1;
    public GameObject tabContent2;
    public GameObject tabContent3;
    public GameObject tabContent4;
    public GameObject tabContent5;
    public GameObject tabContent6;

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

    public void ShowTab4()
    {
        HideAllTabs();
        tabContent4.SetActive(true);
    }

    public void ShowTab5()
    {
        HideAllTabs();
        tabContent5.SetActive(true);
    }

    public void ShowTab6()
    {
        HideAllTabs();
        tabContent6.SetActive(true);
    }

    public void HideAllTabs()
    {

        tabContent1.SetActive(false);
        tabContent2.SetActive(false);
        tabContent3.SetActive(false);
        tabContent4.SetActive(false);
        tabContent5.SetActive(false);
        tabContent6.SetActive(false);

    }
}
