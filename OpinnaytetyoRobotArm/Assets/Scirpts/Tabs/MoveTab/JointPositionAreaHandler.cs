using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointPositionAreaHandler : MonoBehaviour
{
    public float speed = 3.0f;
    public float angle = 1.0f;

    public List<GameObject> joints;

    public void IncreaseBaseRotation()
    {
        Debug.Log("Button increase was clicked");

        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 y = new Vector3(0, joints[0].transform.localEulerAngles.y + angle, 0);
        joints[0].transform.localRotation = Quaternion.Euler(y);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();


    }

    public void DecreseBaseRotation()
    {
        Debug.Log("Button decrese was clicked");

        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 y = new Vector3(0, joints[0].transform.localEulerAngles.y - angle, 0);
        joints[0].transform.localRotation = Quaternion.Euler(y);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();

    }

    public void IncreaseShoulderRotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joints[01].transform.localEulerAngles.z + angle);
        joints[1].transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void DecreseShoulderRotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joints[1].transform.localEulerAngles.z - angle);
        joints[1].transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void IncreaseElbowRotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joints[2].transform.localEulerAngles.z + angle);
        joints[2].transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void DecreseElbowRotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joints[2].transform.localEulerAngles.z - angle);
        joints[2].transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void IncreaseWrist1Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joints[3].transform.localEulerAngles.z + angle);
        joints[3].transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void DecreseWrist1Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joints[3].transform.localEulerAngles.z - angle);
        joints[3].transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void IncreaseWrist2Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 y = new Vector3(0, joints[4].transform.localEulerAngles.y + angle, 0);
        joints[4].transform.localRotation = Quaternion.Euler(y);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void DecreseWrist2Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 y = new Vector3(0, joints[4].transform.localEulerAngles.y - angle, 0);
        joints[4].transform.localRotation = Quaternion.Euler(y);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void IncreaseWrist3Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joints[5].transform.localEulerAngles.z + angle);
        joints[5].transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }

    public void DecreseWrist3Rotation()
    {
        GameObject.Find("IKManager").GetComponent<IKManager>().inverseKinematicsOn = false;

        Vector3 z = new Vector3(0, 0, joints[5].transform.localEulerAngles.z - angle);
        joints[5].transform.localRotation = Quaternion.Euler(z);

        GameObject.Find("IKManager").GetComponent<IKManager>().SetInverseKinematicOn();
    }
}
