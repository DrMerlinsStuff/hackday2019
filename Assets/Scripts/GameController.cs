using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GameController : MonoBehaviour
{
    private GameObject leftControllerEvents;
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
        SceneObjects.GestureRig.enabled = false;
    }

    //Need to figure out how to OnDisable to unsubscribe from events

    void Update()
    {
    }


    //TODO - check when touching or holding on to gameObject. Disable if so. 
}
