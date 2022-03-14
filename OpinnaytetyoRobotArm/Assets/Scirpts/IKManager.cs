using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class IKManager : MonoBehaviour
{
    //Root of the arms
    public Joint root;

    //End effector
    public Joint endJoint;

    public GameObject ikTarget;

    public GameObject joint1;
    public GameObject joint2;
    public GameObject joint3;
    public GameObject joint4;
    public GameObject joint5;
    public GameObject joint6;

    public InputField joint1InputField;
    public InputField joint2InputField;
    public InputField joint3InputField;
    public InputField joint4InputField;
    public InputField joint5InputField;
    public InputField joint6InputField;

    //public Input joint1InputField;

    //public GameObject gripper;
    //public GameObject pickableObject;

    private bool isGripped = false;

    public TextMeshPro test123;

    public float ikThreshold = 0.005f;

    public float ikRate = 10.0f;

    public int ikSteps = 10;

    private int listIndex = 0;

    public float rotationSpeed = 0f;

    public bool inverseKinematicsOn = true;

    private List<Quaternion> joint1Values = new List<Quaternion>();
    private List<Quaternion> joint2Values = new List<Quaternion>();
    private List<Quaternion> joint3Values = new List<Quaternion>();
    private List<Quaternion> joint4Values = new List<Quaternion>();
    private List<Quaternion> joint5Values = new List<Quaternion>();
    private List<Quaternion> joint6Values = new List<Quaternion>();

    private float joint1RotationValue;
    private float joint2RotationValue;
    private float joint3RotationValue;
    private float joint4RotationValue;
    private float joint5RotationValue;
    private float joint6RotationValue;



    float CalculateSlope(Joint _joint)
    {
        float deltaTheta = 0.01f;
        float distance1 = GetDistance(endJoint.transform.position, ikTarget.transform.position - (joint6.transform.forward * 0.2f));

        _joint.Rotate(deltaTheta);

        float distance2 = GetDistance(endJoint.transform.position, ikTarget.transform.position - (joint6.transform.forward * 0.2f));

        _joint.Rotate(-deltaTheta);

        return (distance2 - distance1) / deltaTheta;
    }


    // Update is called once per frame
    void Update()
    {

        bool downZ = Input.GetKeyDown(KeyCode.Z);
        bool downX = Input.GetKeyDown(KeyCode.X);
        bool downC = Input.GetKeyDown(KeyCode.C);


        //Move robots joints to the target with inverse kinematics
        if (inverseKinematicsOn == true)
        {
            for (int i = 0; i < ikSteps; i++)
            {
                if (GetDistance(endJoint.transform.position, ikTarget.transform.position - (joint6.transform.forward * 0.2f)) > ikThreshold)
                {
                    Joint current = root;
                    while (current != null)
                    {
                        float slope = CalculateSlope(current);
                        current.Rotate(-slope * ikRate);
                        current = current.GetChild();
                    }

                }
            }
        }
        else //move joints between saved positions
        {
            rotationSpeed = 10f * Time.fixedDeltaTime;

            if(joint1Values.Count > 0)
            {
                joint1.transform.rotation = Quaternion.RotateTowards(joint1.transform.rotation, joint1Values[listIndex], rotationSpeed);
                joint1.transform.localEulerAngles = new Vector3(0, joint1.transform.localEulerAngles.y, 0);
                joint2.transform.rotation = Quaternion.RotateTowards(joint2.transform.rotation, joint2Values[listIndex], rotationSpeed);
                joint2.transform.localEulerAngles = new Vector3(0, 0, joint2.transform.localEulerAngles.z);
                joint3.transform.rotation = Quaternion.RotateTowards(joint3.transform.rotation, joint3Values[listIndex], rotationSpeed);
                joint3.transform.localEulerAngles = new Vector3(0, 0, joint3.transform.localEulerAngles.z);
                joint4.transform.rotation = Quaternion.RotateTowards(joint4.transform.rotation, joint4Values[listIndex], rotationSpeed);
                joint4.transform.localEulerAngles = new Vector3(0, 0, joint4.transform.localEulerAngles.z);
                joint5.transform.rotation = Quaternion.RotateTowards(joint5.transform.rotation, joint5Values[listIndex], rotationSpeed);
                joint5.transform.localEulerAngles = new Vector3(0, joint5.transform.localEulerAngles.y, 0);
                joint6.transform.rotation = Quaternion.RotateTowards(joint6.transform.rotation, joint6Values[listIndex], rotationSpeed);
                joint6.transform.localEulerAngles = new Vector3(0, 0, joint6.transform.localEulerAngles.z);

                if (Quaternion.Angle(joint1.transform.rotation, joint1Values[listIndex]) <= 0 &&
                Quaternion.Angle(joint2.transform.rotation, joint2Values[listIndex]) <= 0 &&
                Quaternion.Angle(joint3.transform.rotation, joint3Values[listIndex]) <= 0 &&
                Quaternion.Angle(joint4.transform.rotation, joint4Values[listIndex]) <= 0 &&
                Quaternion.Angle(joint5.transform.rotation, joint5Values[listIndex]) <= 0 &&
                Quaternion.Angle(joint6.transform.rotation, joint6Values[listIndex]) <= 0)
                {
                    if (listIndex < joint1Values.Count - 1)
                    {
                        listIndex++;
                    }
                    else
                    {
                        listIndex = 0;
                    }

                }
            }

        }

        GetJointRotation();
        test123.SetText("Joint1: {0}\r\nJoint2: {1}\r\nJoint3: {2}\r\nJoint4: {3}\r\nJoint5: {4}\r\nJoint6: {5}",joint1RotationValue, joint2RotationValue, joint3RotationValue, joint4RotationValue, joint5RotationValue, joint6RotationValue);

        joint1InputField.text = joint1RotationValue.ToString();
        joint2InputField.text = joint2RotationValue.ToString();
        joint3InputField.text = joint3RotationValue.ToString();
        joint4InputField.text = joint4RotationValue.ToString();
        joint5InputField.text = joint5RotationValue.ToString();
        joint6InputField.text = joint6RotationValue.ToString();

        if (downZ)
        {
            SaveJointRotationValues();

        }

        if (downX)
        {
            ResetRotationValues();
        }

        if (downC)
        {
            MoveBetweenPoints();
        }

    }

    float GetDistance(Vector3 _point1, Vector3 _point2)
    {
        return Vector3.Distance(_point1, _point2);
    }

    //Gets joints rotation values and rounds them to 2 deicmal places
    void GetJointRotation()
    {
        joint1RotationValue = (float)Math.Round(joint1.transform.localEulerAngles.y, 2);
        joint2RotationValue = (float)Math.Round(joint2.transform.localEulerAngles.z, 2);
        joint3RotationValue = (float)Math.Round(joint3.transform.localEulerAngles.z, 2); 
        joint4RotationValue = (float)Math.Round(joint4.transform.localEulerAngles.z, 2); 
        joint5RotationValue = (float)Math.Round(joint5.transform.localEulerAngles.y, 2); 
        joint6RotationValue = (float)Math.Round(joint6.transform.localEulerAngles.z, 2); 
    }

    public void SaveJointRotationValues()
    {
        joint1Values.Add(joint1.transform.rotation);
        joint2Values.Add(joint2.transform.rotation);
        joint3Values.Add(joint3.transform.rotation);
        joint4Values.Add(joint4.transform.rotation);
        joint5Values.Add(joint5.transform.rotation);
        joint6Values.Add(joint6.transform.rotation);

        Debug.Log("Got start values");
    }

    public void ResetRotationValues()
    {
        joint1Values.Clear();
        joint2Values.Clear();
        joint3Values.Clear();
        joint4Values.Clear();
        joint5Values.Clear();
        joint6Values.Clear();

        Debug.Log("Values cleared");
    }

    public void MoveBetweenPoints()
    {
        if (inverseKinematicsOn == true)
        {
            inverseKinematicsOn = false;
        }
        else
        {
            SetInverseKinematicOn();
        }
    }

    void SetInverseKinematicOff()
    {
        inverseKinematicsOn = false;
    }

    public void SetInverseKinematicOn()
    {
        inverseKinematicsOn = true;
        ikTarget.transform.position = joint6.transform.position + (joint6.transform.forward * 0.2f);
    }

}
