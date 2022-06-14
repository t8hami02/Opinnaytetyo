using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gripper : MonoBehaviour
{
    public GameObject finger1;
    public GameObject finger2;

    public GameObject gripper1;
    public GameObject gripper2;

    public GameObject pickableObject;

    public float speed = 0.1f;

    //private bool isGripper1 = true;

    private bool isOpen = true;
    private bool isMoving = false;
    private bool isGripping = false;
    private float open1 = 0.0f;
    private float open2 = 0.0f;
    private float close1 = 0.0f;
    private float close2 = 0.0f;
    private float closeDistance1 = 0.0f;
    private float closeDistance2 = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isOpen == true && isMoving == true)
        {          
            finger1.transform.Translate(Vector3.back * Time.deltaTime * speed);
            finger2.transform.Translate(Vector3.back * Time.deltaTime * speed);

        }

        if (isOpen == false && isMoving == true)
        {
            if (closeDistance1 >= close1 - finger1.transform.position.z)
            {
                finger1.transform.Translate(Vector3.forward * Time.deltaTime * speed);

            }
            else
            {
                isOpen = true;
                isMoving = false;
            }
            if (closeDistance2 <= close2 - finger2.transform.position.z)
            {
                finger2.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else
            {
                isOpen = true;
                isMoving = false;
                
            }
            if(isGripping == true)
            {
                pickableObject.transform.parent = null;
                pickableObject.GetComponent<Rigidbody>().useGravity = true;
                isGripping = false;
            }

        }

    }

    public void PullTrigger(Collider c)
    {
        Debug.Log(c.gameObject.name + " on layer " + c.gameObject.layer);

        if (isMoving == true)
        {
            closeDistance1 = finger1.transform.position.z - open1;
            closeDistance2 = finger2.transform.position.z - open2;

            isOpen = false;
            isMoving = false;

            if (c.gameObject.layer == LayerMask.NameToLayer("Pickable"))
            {
                pickableObject.transform.parent = this.transform;
                pickableObject.GetComponent<Rigidbody>().useGravity = false;
                isGripping = true;
            }          
        }
    }

    public void OpenCloseGripper()
    {
        if (isMoving == false)
        {
            if (isOpen == true)
            {
                open1 = finger1.transform.position.z;
                open2 = finger2.transform.position.z;
            }
            else
            {
                close1 = finger1.transform.position.z;
                close2 = finger2.transform.position.z;
            }

            isMoving = true;
        }
    }

    public void ChangeGripper()
    {
        gripper1.SetActive(false);
        gripper2.SetActive(true);

        //if (isGripper1 == true)
        //{
        //    gripper1.SetActive(false);
        //    gripper2.SetActive(true);

        //    isGripper1 = false;
        //}
        //else
        //{
        //    gripper1.SetActive(true);
        //    gripper2.SetActive(false);

        //    isGripper1 = true;
        //}
    }

    public bool IsGripperMoving()
    {

        return isMoving;
    }
}
