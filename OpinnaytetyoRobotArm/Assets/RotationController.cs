using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{

    public GameObject joint1;
    public GameObject joint2;
    public GameObject joint3;
    public GameObject joint4;
    public GameObject joint5;
    public GameObject joint6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        bool downA = Input.GetKeyDown(KeyCode.A);
        bool downZ = Input.GetKeyDown(KeyCode.Z);

        bool downS = Input.GetKeyDown(KeyCode.S);
        bool downX = Input.GetKeyDown(KeyCode.X);

        bool downD = Input.GetKeyDown(KeyCode.D);
        bool downC = Input.GetKeyDown(KeyCode.C);

        bool downI = Input.GetKeyDown(KeyCode.I);
        bool downK = Input.GetKeyDown(KeyCode.K);

        bool downO = Input.GetKeyDown(KeyCode.O);
        bool downL = Input.GetKeyDown(KeyCode.L);

        bool downN = Input.GetKeyDown(KeyCode.N);
        bool downM = Input.GetKeyDown(KeyCode.M);

        if (downA)
        {
            joint1.transform.Rotate(0, 5, 0);
        }

        if (downZ)
        {
            joint1.transform.Rotate(0, -5, 0);
        }


        if (downS)
        {
            joint2.transform.Rotate(0, 0, 5);
        }

        if (downX)
        {
            joint2.transform.Rotate(0, 0, -5);
        }


        if (downD)
        {
            joint3.transform.Rotate(0, 0, 5);
        }

        if (downC)
        {
            joint3.transform.Rotate(0, 0, -5);
        }


        if (downI)
        {
            joint4.transform.Rotate(0, 0, 5);
        }

        if (downK)
        {
            joint4.transform.Rotate(0, 0, -5);
        }


        if (downO)
        {
            joint5.transform.Rotate(0, 5, 0);
        }

        if (downL)
        {
            joint5.transform.Rotate(0, -5, 0);
        }


        if (downN)
        {
            joint6.transform.Rotate(0, 0, 5);
        }

        if (downM)
        {
            joint6.transform.Rotate(0, 0, -5);
        }

    }
}
