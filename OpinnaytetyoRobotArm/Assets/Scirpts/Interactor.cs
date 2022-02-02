using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayermask;
    UnityEvent onInteract;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayermask))
        {
            if(hit.collider.GetComponent<Interactable>() != false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                   
                }
            }
        }
    }
}
