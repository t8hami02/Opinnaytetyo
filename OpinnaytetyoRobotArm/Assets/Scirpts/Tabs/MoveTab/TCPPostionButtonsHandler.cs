using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCPPostionButtonsHandler : MonoBehaviour
{
    public GameObject target;

    public float speed = 3.0f;

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

}
