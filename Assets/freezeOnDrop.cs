using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class freezeOnDrop : MonoBehaviour
{

    VRTK_InteractableObject interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<VRTK_InteractableObject>();
        interactable.InteractableObjectUngrabbed += OnUngrab;
        interactable.InteractableObjectGrabbed += OnGrab;
    }

    private void OnGrab(object sender, InteractableObjectEventArgs e)
    {
        Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
        VRTK_Logger.Info("OnGrab" + (rigidBody == null).ToString());
        if (rigidBody != null)
        {
            //rigidBody.WakeUp();
            rigidBody.constraints = RigidbodyConstraints.None;
            //rigidBody.freezeRotation = false;
            //rigidBody.useGravity = true;

        }
    }

    private void OnUngrab(object sender, InteractableObjectEventArgs e)
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        //gameObject.GetComponent<Rigidbody>().Sleep();
        //gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        //gameObject.GetComponent<Rigidbody>().useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
