using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Joint m_child;
    public bool rotateZAngle = false;
    public bool isLocked = false;
    
    public Joint GetChild()
    {
        return m_child;
    }
    

    public void Rotate(float _angle)
    {
        if (rotateZAngle == false)
        {
            transform.Rotate(Vector3.up * _angle);
        }
        else
        {
            transform.Rotate(Vector3.forward * _angle);
        }
    }
}
