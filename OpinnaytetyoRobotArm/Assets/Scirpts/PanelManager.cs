using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject target;

    public GameObject joint1;
    public GameObject joint2;
    public GameObject joint3;
    public GameObject joint4;
    public GameObject joint5;
    public GameObject joint6;

    //public GameObject gripper1;
    //public GameObject gripper2;

    public float speed = 3.0f;
    public float angle = 1.0f;

    private bool isGripper1 = true;


    public void MoveRight()
    {
        target.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void MoveLeft()
    {
        target.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void MoveForward()
    {
        target.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void MoveBack()
    {
        target.transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    public void MoveUp()
    {
        target.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void MoveDown()
    {
        target.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void IncreaseJoint1Rotation()
    {
        Debug.Log("Button increase was clicked");

        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 y = new Vector3(0, joint1.transform.localEulerAngles.y + angle, 0);
        joint1.transform.localRotation = Quaternion.Euler(y);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();

        
    }

    public void DecreseJoint1Rotation()
    {
        Debug.Log("Button decrese was clicked");

        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 y = new Vector3(0, joint1.transform.localEulerAngles.y - angle, 0);
        joint1.transform.localRotation = Quaternion.Euler(y);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
      
    }

    public void IncreaseJoint2Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joint2.transform.localEulerAngles.z + angle);
        joint2.transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void DecreseJoint2Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joint2.transform.localEulerAngles.z - angle);
        joint2.transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void IncreaseJoint3Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joint3.transform.localEulerAngles.z + angle);
        joint3.transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void DecreseJoint3Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joint3.transform.localEulerAngles.z - angle);
        joint3.transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void IncreaseJoint4Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joint4.transform.localEulerAngles.z + angle);
        joint4.transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void DecreseJoint4Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joint4.transform.localEulerAngles.z - angle);
        joint4.transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void IncreaseJoint5Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 y = new Vector3(0, joint5.transform.localEulerAngles.y + angle, 0);
        joint5.transform.localRotation = Quaternion.Euler(y);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void DecreseJoint5Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 y = new Vector3(0, joint5.transform.localEulerAngles.y - angle, 0);
        joint5.transform.localRotation = Quaternion.Euler(y);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void IncreaseJoint6Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joint6.transform.localEulerAngles.z + angle);
        joint6.transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void DecreseJoint6Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joint6.transform.localEulerAngles.z - angle);
        joint6.transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void ChangeGripper()
    {
        if(isGripper1 == true)
        {
            isGripper1 = false;
            GameObject.Find("ROBOTIQ_HAND-E_DEFEATURE_NO_FINGERTIPS").GetComponent<Gripper>().ChangeGripper();

        }
        else
        {
            isGripper1 = true;
            GameObject.Find("EPick - ENSEMBLE 4 VENTOUSES").GetComponent<Gripper2>().ChangeGripper2();

        }
    }

    public void SavePoint()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().SaveJointRotationValues();
    }

    public void MoveBetweenPoints()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().MoveBetweenPoints();
    }

    public void ClearPoints()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().ResetRotationValues();
    }

    public void OpenOrCloseGripper()
    {
        GameObject.Find("ROBOTIQ_HAND-E_DEFEATURE_NO_FINGERTIPS").GetComponent<Gripper>().OpenCloseGripper();
    }
}
