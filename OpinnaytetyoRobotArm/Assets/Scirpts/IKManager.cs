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

    public List<GameObject> joints;

    //public GameObject joint1;
    //public GameObject joint2;
    //public GameObject joint3;
    //public GameObject joint4;
    //public GameObject joint5;
    //public GameObject joint6;

    public List<TMP_InputField> jointInputFields;

    //public TMP_InputField joint1InputField;
    //public TMP_InputField joint2InputField;
    //public TMP_InputField joint3InputField;
    //public TMP_InputField joint4InputField;
    //public TMP_InputField joint5InputField;
    //public TMP_InputField joint6InputField;

    public float ikThreshold = 0.005f;

    public float ikRate = 10.0f;

    public int ikSteps = 10;

    private int listIndex = 0;

    public float rotationSpeed = 10f;

    private float timer = 0;

    public bool inverseKinematicsOn = true;
    public bool isMovingBetweenPointsOn = false;
    
    private List<int> moveOrderIndex = new List<int>(); 

    private List<Quaternion> joint1Values = new List<Quaternion>();
    private List<Quaternion> joint2Values = new List<Quaternion>();
    private List<Quaternion> joint3Values = new List<Quaternion>();
    private List<Quaternion> joint4Values = new List<Quaternion>();
    private List<Quaternion> joint5Values = new List<Quaternion>();
    private List<Quaternion> joint6Values = new List<Quaternion>();

    private List<float> jointRotationValues = new List<float>(new float[6]);

    //private float joint1RotationValue;
    //private float joint2RotationValue;
    //private float joint3RotationValue;
    //private float joint4RotationValue;
    //private float joint5RotationValue;
    //private float joint6RotationValue;

    //private RobotProgramOrder test = new RobotProgramOrder();
    private List<RobotProgramOrder> robotOrders = new List<RobotProgramOrder>();
    private List<RobotProgramOrder> rearrangeRobotOrders = new List<RobotProgramOrder>();

    private bool gripperSetToMove = false;

    float CalculateSlope(Joint _joint)
    {
        float deltaTheta = 0.01f;
        float distance1 = GetDistance(endJoint.transform.position, ikTarget.transform.position - (joints[5].transform.forward * 0.2f));

        _joint.Rotate(deltaTheta);

        float distance2 = GetDistance(endJoint.transform.position, ikTarget.transform.position - (joints[5].transform.forward * 0.2f));

        _joint.Rotate(-deltaTheta);

        return (distance2 - distance1) / deltaTheta;
    }

    // Update is called once per frame
    void Update()
    {
        //Move robots joints to the target with inverse kinematics
        if (inverseKinematicsOn == true)
        {
            InverseKinematicsCalc();
        }
        else if(isMovingBetweenPointsOn == true)//move joints between saved positions
        {
            MoveBetweenPoints();
        }

        GetJointRotation();        

        for (int i = 0; i < jointInputFields.Count; i++)
        {
            jointInputFields[i].text = jointRotationValues[i].ToString();
        }
    }

    float GetDistance(Vector3 _point1, Vector3 _point2)
    {
        return Vector3.Distance(_point1, _point2);
    }

    //Gets joints rotation values and rounds them to 2 deicmal places
    void GetJointRotation()
    {
        for(int i = 0; i < jointRotationValues.Count; i++)
        {
            if (joints[i].GetComponent<Joint>().GetRotateZAngle() == true)
            {
                jointRotationValues[i] = (float)Math.Round(joints[i].transform.localEulerAngles.z, 2);
            }
            else
            {
                jointRotationValues[i] = (float)Math.Round(joints[i].transform.localEulerAngles.y, 2);
            }
        }

        // old way, remove later
        //joint1RotationValue = (float)Math.Round(joint1.transform.localEulerAngles.y, 2);

    }

    //public void SaveJointRotationValues(int orderIndex)
    //{
    //    joint1Values.Add(joint1.transform.rotation);
    //    joint2Values.Add(joint2.transform.rotation);
    //    joint3Values.Add(joint3.transform.rotation);
    //    joint4Values.Add(joint4.transform.rotation);
    //    joint5Values.Add(joint5.transform.rotation);
    //    joint6Values.Add(joint6.transform.rotation);

    //    moveOrderIndex.Add(orderIndex);

    //    Debug.Log("Got start values");
    //}

    public void AddNewOrder(int orderIndex, int type)
    {
        //Assign correct orderindex for robotOrders list variables
        for (int i = 0; i < robotOrders.Count; i++)
        {
            if (orderIndex <= robotOrders[i].OrderIndex)
            {
                robotOrders[i].OrderIndex = robotOrders[i].OrderIndex + 1;
            }
        }

        if (type == 1) //Add waypoint type order
        {
            List<Quaternion> jointValues = new List<Quaternion>();

            for (int i = 0; i < joints.Count; i++)
            {
                jointValues.Add(joints[i].transform.rotation);
            }

            RobotProgramOrder waypoint = new RobotProgramOrder(type, orderIndex, jointValues);
            robotOrders.Add(waypoint);
        }
        else if(type == 2) //Add wait type order
        {
            RobotProgramOrder wait = new RobotProgramOrder(type, orderIndex, null);
            robotOrders.Add(wait);
        }
        else if (type == 3) //Add set type order
        {
            RobotProgramOrder set = new RobotProgramOrder(type, orderIndex, null);
            robotOrders.Add(set);
        }

        
    }

    public void EditOrder(int orderIndex, int type)
    {
        int indexInList = 0;
        for (int i = 0; i < robotOrders.Count; i++)
        {
            if (robotOrders[i].OrderIndex == orderIndex)
            {
                indexInList = i;
                break;
            }
        }

        if (type == 1) //Edit waypoint type order
        {
            List<Quaternion> jointValues = new List<Quaternion>();

            for (int i = 0; i < joints.Count; i++)
            {
                jointValues.Add(joints[i].transform.rotation);
            }

            robotOrders[indexInList].JointRotationValues = jointValues;
        }
        //else if (type == 2) //Edit wait type order
        //{
        //    RobotProgramOrder wait = new RobotProgramOrder(type, orderIndex, null);
        //    robotOrders.Add(wait);
        //}
        //else if (type == 3) //Edit set type order
        //{
        //    RobotProgramOrder set = new RobotProgramOrder(type, orderIndex, null);
        //    robotOrders.Add(set);
        //}
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

    public void RemoveLastSavedPoint()
    {
        joint1Values.RemoveAt(joint1Values.Count - 1);
        joint2Values.RemoveAt(joint2Values.Count - 1);
        joint3Values.RemoveAt(joint3Values.Count - 1);
        joint4Values.RemoveAt(joint4Values.Count - 1);
        joint5Values.RemoveAt(joint5Values.Count - 1);
        joint6Values.RemoveAt(joint6Values.Count - 1);

    }

    public void RemoveAtIndex(int givenIndex)
    {      
        int indexInList = 0;

        //foreach (RobotProgramOrder order in robotOrders)
        //{
        //    if (order.OrderIndex == givenIndex)
        //    {
        //        indexInList = robotOrders.IndexOf(order);
        //        break;
        //    }
        //}

        //Get the robotOrders list's index of the variable which is going to be removed 
        for (int i = 0; i < robotOrders.Count; i++)
        {
            if (robotOrders[i].OrderIndex == givenIndex)
            {
                indexInList = i;
                break;
            }
        }

        robotOrders.RemoveAt(indexInList);

        //Assign correct orderindex for robotOrders list variables
        for (int i = 0; i < robotOrders.Count; i++)
        {
            if (givenIndex < robotOrders[i].OrderIndex)
            {
                robotOrders[i].OrderIndex = robotOrders[i].OrderIndex - 1;
            }
        }
    }

    public void RearrangeOrderList()
    {
        rearrangeRobotOrders.Clear();
        for(int i = 0; i < robotOrders.Count; i++)
        {
            foreach (RobotProgramOrder order in robotOrders)
            {
                if(order.OrderIndex == i)
                {
                    RobotProgramOrder wantedOrder = order;
                    rearrangeRobotOrders.Add(wantedOrder);
                }

            }            
        }
    }


    public void MoveBetweenPointsSwitch()
    {

        if (inverseKinematicsOn == true)
        {
            RearrangeOrderList();
            inverseKinematicsOn = false;
            isMovingBetweenPointsOn = true;
        }
        else
        {
            SetInverseKinematicOn();
        }
    }

    public void SetInverseKinematicOff()
    {
        inverseKinematicsOn = false;
        ikTarget.transform.position = joints[5].transform.position + (joints[5].transform.forward * 0.2f);
    }

    public void SetInverseKinematicOn()
    {
        inverseKinematicsOn = true;
        isMovingBetweenPointsOn = false;
        // Set target on robots current position
        ikTarget.transform.position = joints[5].transform.position + (joints[5].transform.forward * 0.2f);
    }

    public void SetIsMovingBetweenPointsOnTrue()
    {
        isMovingBetweenPointsOn = true;
    }

    public void InverseKinematicsCalc()
    {
        for (int i = 0; i < ikSteps; i++)
        {
            if (GetDistance(endJoint.transform.position, ikTarget.transform.position - (joints[5].transform.forward * 0.2f)) > ikThreshold)
            {
                Joint current = root;
                while (current != null)
                {
                    if (current.isLocked == false)
                    {
                        float slope = CalculateSlope(current);
                        current.Rotate(-slope * ikRate);
                    }
                    current = current.GetChild();
                }

            }
        }
    }

    public void MoveBetweenPoints()
    {
        rotationSpeed = 50f * Time.fixedDeltaTime;
        if(listIndex >= rearrangeRobotOrders.Count)
        {
            listIndex = 0;
        }

        if (rearrangeRobotOrders.Count > 0)
        {
            if (rearrangeRobotOrders[listIndex].Type == 1) // waypoint type order fuction
            {
                for (int i = 0; i < joints.Count; i++)
                {

                    if (joints[i].GetComponent<Joint>().GetRotateZAngle() == true)
                    {
                        joints[i].transform.rotation = Quaternion.RotateTowards(joints[i].transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[i], rotationSpeed);
                        joints[i].transform.localEulerAngles = new Vector3(0, 0, joints[i].transform.localEulerAngles.z);
                    }
                    else
                    {
                        joints[i].transform.rotation = Quaternion.RotateTowards(joints[i].transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[i], rotationSpeed);
                        joints[i].transform.localEulerAngles = new Vector3(0, joints[i].transform.localEulerAngles.y, 0);
                    }

                    // Old way to do this, remove later
                    //        //joint1.transform.rotation = Quaternion.RotateTowards(joint1.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[0], rotationSpeed);
                    //        //joint1.transform.localEulerAngles = new Vector3(0, joint1.transform.localEulerAngles.y, 0);

                }

                // process to next order if each joint is at saved point's angle
                if (Quaternion.Angle(joints[0].transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[0]) <= 0 &&
                Quaternion.Angle(joints[1].transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[1]) <= 0 &&
                Quaternion.Angle(joints[2].transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[2]) <= 0 &&
                Quaternion.Angle(joints[3].transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[3]) <= 0 &&
                Quaternion.Angle(joints[4].transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[4]) <= 0 &&
                Quaternion.Angle(joints[5].transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[5]) <= 0)
                {
                    if (listIndex < rearrangeRobotOrders.Count - 1)
                    {
                        listIndex++;
                    }
                    else
                    {
                        listIndex = 0;
                    }

                }
            }
            else if (rearrangeRobotOrders[listIndex].Type == 2) // wait type order fuction, currently waits 2 seconds at every wait order
            {
                timer += Time.deltaTime;

                if (timer > 2)
                {
                    Debug.Log("Done waiting");

                    listIndex++;
                    timer = 0;
                }
            }
            else if (rearrangeRobotOrders[listIndex].Type == 3) // set type order fuction, currently waits 2 seconds at every wait order
            {
                if(gripperSetToMove == false)
                {
                    gripperSetToMove = true;
                    GameObject.Find("ROBOTIQ_HAND-E_DEFEATURE_NO_FINGERTIPS").GetComponent<Gripper>().OpenCloseGripper();                    
                }
                else
                {
                    if (!GameObject.Find("ROBOTIQ_HAND-E_DEFEATURE_NO_FINGERTIPS").GetComponent<Gripper>().IsGripperMoving())
                    {
                        listIndex++;
                        gripperSetToMove = false;
                    }
                }
                
            }
        }
    }
}
