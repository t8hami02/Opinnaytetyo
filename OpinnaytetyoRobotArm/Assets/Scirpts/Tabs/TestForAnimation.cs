using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForAnimation : MonoBehaviour
{
    private Animator myAnimator;
    bool myBool = true;

    public GameObject screw1;
    public GameObject screw2;
    public GameObject screw3;
    public GameObject screw4;

    public GameObject gripper1;
    public GameObject gripper2;

    public bool isGripper1On = true;
    public bool isScrewsActive = true;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(myAnimator != null)
        {
            if (myBool == true)
            {               
                myAnimator.SetTrigger("Change1");
                myBool = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            myAnimator.SetTrigger("Change1");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            myAnimator.SetTrigger("Change2");
        }
    }

    public void HideScrews()
    {
        screw1.SetActive(false);
        screw2.SetActive(false);
        screw3.SetActive(false);
        screw4.SetActive(false);
    }

    public void ShowScrews()
    {
        screw1.SetActive(true);
        screw2.SetActive(true);
        screw3.SetActive(true);
        screw4.SetActive(true);
    }

    public void ChangeScrews()
    {
        if (isScrewsActive == true)
        {
            HideScrews();
            isScrewsActive = false;
        }
        else
        {
            ShowScrews();
            isScrewsActive = true;
        }
    }

    public void ShowGripper1()
    {
        gripper2.SetActive(false);
        ShowScrews();
        gripper1.SetActive(true);
    }

    public void ShowGripper2()
    {
        gripper1.SetActive(false);
        gripper2.SetActive(true);
    }

    public void ChangeGripper()
    {
        if(isGripper1On == true)
        {
            gripper1.SetActive(false);
            ShowScrews();
            gripper2.SetActive(true);
            isGripper1On = false;
        }
        else
        {
            gripper2.SetActive(false);
            gripper1.SetActive(true);
            HideScrews();
            isGripper1On = true;
        }
    }
}
