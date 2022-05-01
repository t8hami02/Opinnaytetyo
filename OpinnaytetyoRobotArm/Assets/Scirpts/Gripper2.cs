using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gripper2 : MonoBehaviour
{
    public GameObject gripper1;
    public GameObject gripper2;

    public GameObject pickableObject;
    private bool isGripping = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGripping == true)
        {
            pickableObject.transform.parent = null;
            pickableObject.GetComponent<Rigidbody>().useGravity = true;
            isGripping = false;
        }
    }

    public void PullTrigger(Collider c)
    {
        Debug.Log(c.gameObject.name + " on layer " + c.gameObject.layer);

        if (c.gameObject.layer == LayerMask.NameToLayer("Pickable"))
        {
            pickableObject.transform.parent = this.transform;
            pickableObject.GetComponent<Rigidbody>().useGravity = false;
            isGripping = true;
        }
    }

    public void ChangeGripper2()
    {
        gripper1.SetActive(true);
        gripper2.SetActive(false);
    }
}
