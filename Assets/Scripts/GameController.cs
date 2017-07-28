using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GameController : MonoBehaviour
{
    public GameObject dough;

    private VRTK_InteractGrab leftControllerGrab;
    private VRTK_InteractGrab rightControllerGrab;
    // Use this for initialization

    void Awake()
    {
        VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
    }

    void OnDestroy()
    {
        VRTK_SDKManager.instance.RemoveBehaviourToToggleOnLoadedSetupChange(this);
    }

    void OnEnable()
    {
        leftControllerGrab = SceneObjects.LeftController.GetComponent<VRTK_InteractGrab>();
        rightControllerGrab = SceneObjects.RightController.GetComponent<VRTK_InteractGrab>();

        ObjectFactory.CreateDoughs(dough);
    }

    //Need to figure out how to OnDisable to unsubscribe from events

    void Update()
    {
        if(leftControllerGrab.GetGrabbedObject() != null || rightControllerGrab.GetGrabbedObject() != null)
        {
            SceneObjects.GestureRig.enabled = false;
        }
        else
        {
            SceneObjects.GestureRig.enabled = true;
        }
    }


    //TODO - check when touching or holding on to gameObject. Disable if so. 
}
