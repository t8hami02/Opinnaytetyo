using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGripperHandler : MonoBehaviour
{
    private Animator myAnimator;

    public List<GameObject> screws1;
    public List<GameObject> screws2;

    public GameObject gripper1;
    public GameObject gripper2;

    private bool isGripper1On = true;
    private bool isScrewsActive1 = true;
    private bool isScrewsActive2 = false;



    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.N))
        {
            if(isGripper1On == true)
            {
                myAnimator.SetTrigger("Change1");
            }
            else
            {
                myAnimator.SetTrigger("Change2");
            }
            
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            myAnimator.SetTrigger("Change2");
        }
    }

    public void HideScrews1()
    {
        foreach(GameObject screw in screws1)
        {
            screw.SetActive(false);
        }

    }

    public void ShowScrews1()
    {
        foreach (GameObject screw in screws1)
        {
            screw.SetActive(true);
        }

    }

    public void HideScrews2()
    {
        foreach (GameObject screw in screws2)
        {
            screw.SetActive(false);
        }
    }

    public void ShowScrews2()
    {
        foreach (GameObject screw in screws2)
        {
            screw.SetActive(true);
        }
    }

    public void ChangeScrews1()
    {
        if (isScrewsActive1 == true)
        {
            HideScrews1();
            isScrewsActive1 = false;
        }
        else
        {
            ShowScrews1();
            isScrewsActive1 = true;
        }
    }

    public void ChangeScrews2()
    {
        if (isScrewsActive2 == true)
        {
            HideScrews2();
            isScrewsActive2 = false;
        }
        else
        {
            ShowScrews2();
            isScrewsActive2 = true;
        }
    }

    public void ShowGripper1()
    {
        gripper2.SetActive(false);
        ShowScrews1();
        gripper1.SetActive(true);
    }

    public void ShowGripper2()
    {
        gripper1.SetActive(false);
        gripper2.SetActive(true);
    }

    public void ChangeGripper()
    {        
        if (isGripper1On == true)
        {
            gripper1.SetActive(false);
            ShowScrews1();
            HideScrews2();
            gripper2.SetActive(true);
            isGripper1On = false;
        }
        else
        {
            gripper2.SetActive(false);
            gripper1.SetActive(true);
            HideScrews1();
            isGripper1On = true;
        }
    }

    public void TriggerAnimation()
    {
        if (isGripper1On == true)
        {
            myAnimator.SetTrigger("Change1");
        }
        else
        {
            myAnimator.SetTrigger("Change2");
        }
    }
}
