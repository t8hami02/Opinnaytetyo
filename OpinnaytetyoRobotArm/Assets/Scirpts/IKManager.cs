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

    public GameObject joint1;
    public GameObject joint2;
    public GameObject joint3;
    public GameObject joint4;
    public GameObject joint5;
    public GameObject joint6;

    public List<TMP_InputField> jointInputFields;

    public TMP_InputField joint1InputField;
    public TMP_InputField joint2InputField;
    public TMP_InputField joint3InputField;
    public TMP_InputField joint4InputField;
    public TMP_InputField joint5InputField;
    public TMP_InputField joint6InputField;

    //public Input joint1InputField;

    //public GameObject gripper;
    //public GameObject pickableObject;

    //private bool isGripped = false;

    //public TextMeshPro test123;

    public float ikThreshold = 0.005f;

    public float ikRate = 10.0f;

    public int ikSteps = 10;

    private int listIndex = 0;

    public float rotationSpeed = 10f;

    public bool inverseKinematicsOn = true;
    public bool moveBetweenPointsOn = false;

    private List<int> moveOrderIndex = new List<int>(); 

    private List<Quaternion> joint1Values = new List<Quaternion>();
    private List<Quaternion> joint2Values = new List<Quaternion>();
    private List<Quaternion> joint3Values = new List<Quaternion>();
    private List<Quaternion> joint4Values = new List<Quaternion>();
    private List<Quaternion> joint5Values = new List<Quaternion>();
    private List<Quaternion> joint6Values = new List<Quaternion>();

    private List<float> jointRotationValues = new List<float>(new float[6]);

    private float joint1RotationValue;
    private float joint2RotationValue;
    private float joint3RotationValue;
    private float joint4RotationValue;
    private float joint5RotationValue;
    private float joint6RotationValue;

    //private RobotProgramOrder test = new RobotProgramOrder();
    private List<RobotProgramOrder> robotOrders = new List<RobotProgramOrder>();
    private List<RobotProgramOrder> rearrangeRobotOrders = new List<RobotProgramOrder>();

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
                        if(current.isLocked == false)
                        {
                            float slope = CalculateSlope(current);
                            current.Rotate(-slope * ikRate);
                        }                       
                        current = current.GetChild();
                    }

                }
            }
        }
        else if(moveBetweenPointsOn == true)//move joints between saved positions
        {
            rotationSpeed = 50f * Time.fixedDeltaTime;

            if(rearrangeRobotOrders.Count > 0)
            {
                if (rearrangeRobotOrders[listIndex].Type==1)
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
                    }

                    //joint1.transform.rotation = Quaternion.RotateTowards(joint1.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[0], rotationSpeed);
                    //joint1.transform.localEulerAngles = new Vector3(0, joint1.transform.localEulerAngles.y, 0);
                    //joint2.transform.rotation = Quaternion.RotateTowards(joint2.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[1], rotationSpeed);
                    //joint2.transform.localEulerAngles = new Vector3(0, 0, joint2.transform.localEulerAngles.z);
                    //joint3.transform.rotation = Quaternion.RotateTowards(joint3.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[2], rotationSpeed);
                    //joint3.transform.localEulerAngles = new Vector3(0, 0, joint3.transform.localEulerAngles.z);
                    //joint4.transform.rotation = Quaternion.RotateTowards(joint4.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[3], rotationSpeed);
                    //joint4.transform.localEulerAngles = new Vector3(0, 0, joint4.transform.localEulerAngles.z);
                    //joint5.transform.rotation = Quaternion.RotateTowards(joint5.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[4], rotationSpeed);
                    //joint5.transform.localEulerAngles = new Vector3(0, joint5.transform.localEulerAngles.y, 0);
                    //joint6.transform.rotation = Quaternion.RotateTowards(joint6.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[5], rotationSpeed);
                    //joint6.transform.localEulerAngles = new Vector3(0, 0, joint6.transform.localEulerAngles.z);

                    if (Quaternion.Angle(joint1.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[0]) <= 0 &&
                    Quaternion.Angle(joint2.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[1]) <= 0 &&
                    Quaternion.Angle(joint3.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[2]) <= 0 &&
                    Quaternion.Angle(joint4.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[3]) <= 0 &&
                    Quaternion.Angle(joint5.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[4]) <= 0 &&
                    Quaternion.Angle(joint6.transform.rotation, rearrangeRobotOrders[listIndex].JointRotationValues[5]) <= 0)
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
                else
                {
                    Debug.Log("Trying to wait");

                    StartCoroutine("waiter");
                    listIndex++;
                }
                
            }

        }

        GetJointRotation();
        

        for (int i = 0; i < jointInputFields.Count; i++)
        {
            jointInputFields[i].text = jointRotationValues[i].ToString();
        }

        //joint1InputField.text = joint1RotationValue.ToString();
        //joint2InputField.text = joint2RotationValue.ToString();
        //joint3InputField.text = joint3RotationValue.ToString();
        //joint4InputField.text = joint4RotationValue.ToString();
        //joint5InputField.text = joint5RotationValue.ToString();
        //joint6InputField.text = joint6RotationValue.ToString();


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

        joint1RotationValue = (float)Math.Round(joint1.transform.localEulerAngles.y, 2);
        joint2RotationValue = (float)Math.Round(joint2.transform.localEulerAngles.z, 2);
        joint3RotationValue = (float)Math.Round(joint3.transform.localEulerAngles.z, 2); 
        joint4RotationValue = (float)Math.Round(joint4.transform.localEulerAngles.z, 2); 
        joint5RotationValue = (float)Math.Round(joint5.transform.localEulerAngles.y, 2); 
        joint6RotationValue = (float)Math.Round(joint6.transform.localEulerAngles.z, 2); 
    }

    public void SaveJointRotationValues(int orderIndex)
    {
        joint1Values.Add(joint1.transform.rotation);
        joint2Values.Add(joint2.transform.rotation);
        joint3Values.Add(joint3.transform.rotation);
        joint4Values.Add(joint4.transform.rotation);
        joint5Values.Add(joint5.transform.rotation);
        joint6Values.Add(joint6.transform.rotation);

        moveOrderIndex.Add(orderIndex);

        Debug.Log("Got start values");
    }

    public void SaveWaypointRotationValues(int orderIndex)
    {
        List<Quaternion> jointValues = new List<Quaternion>();

        for (int i = 0; i < joints.Count; i++)
        {
            jointValues.Add(joints[i].transform.rotation);
        }

        //jointValues.Add(joint1.transform.rotation);
        //jointValues.Add(joint2.transform.rotation);
        //jointValues.Add(joint3.transform.rotation);
        //jointValues.Add(joint4.transform.rotation);
        //jointValues.Add(joint5.transform.rotation);
        //jointValues.Add(joint6.transform.rotation);

        RobotProgramOrder waypoint = new RobotProgramOrder(1, orderIndex, jointValues);
           
        robotOrders.Add(waypoint);
    }

    public void AddWaitButton(int orderIndex)
    {
        RobotProgramOrder wait = new RobotProgramOrder(2, orderIndex, null);
        robotOrders.Add(wait);
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
        int getIndex = moveOrderIndex.IndexOf(givenIndex);
        moveOrderIndex.Remove(givenIndex);

        joint1Values.RemoveAt(getIndex);
        joint2Values.RemoveAt(getIndex);
        joint3Values.RemoveAt(getIndex);
        joint4Values.RemoveAt(getIndex);
        joint5Values.RemoveAt(getIndex);
        joint6Values.RemoveAt(getIndex);

        for(int i = 0; i<moveOrderIndex.Count;i++)
        {
            if(getIndex < moveOrderIndex[i])
            {
                moveOrderIndex[i]--;
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


    public void MoveBetweenPoints()
    {       
        if (inverseKinematicsOn == true)
        {
            RearrangeOrderList();
            inverseKinematicsOn = false;
            moveBetweenPointsOn = true;
        }
        else
        {
            SetInverseKinematicOn();
        }
    }

    public void SetInverseKinematicOn()
    {
        inverseKinematicsOn = true;
        moveBetweenPointsOn = false;
        // Set target on robots current position
        ikTarget.transform.position = joint6.transform.position + (joint6.transform.forward * 0.2f);
    }

    IEnumerator waiter()
    {
        //Wait for 3 seconds
        Debug.Log("Starting waiting");
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("Stopped waiting");

    }

}
