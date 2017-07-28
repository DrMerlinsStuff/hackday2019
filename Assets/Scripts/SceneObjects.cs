using Edwon.VR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public static class SceneObjects
{
    private static VRGestureRig gestureRig;
    private static GameObject leftController;
    private static GameObject rightController;
    private static VRTK_ControllerEvents leftControllerEvents;
    private static VRTK_ControllerEvents rightControllerEvents;


    public static VRGestureRig GestureRig
    {
        get
        {
            if (gestureRig == null)
            {
                //Dont know of a better way than the .Find()  :( 
                gestureRig = GameObject.Find("[CameraRig]").GetComponent<VRGestureRig>();
            }

            return gestureRig;
        }
    }

    public static GameObject LeftController
    {
        get
        {
            if(leftController == null)
            {
                leftController = VRTK_DeviceFinder.GetControllerLeftHand();
            }

            return leftController;
        }
    }

    //In order for this to work, you have to subscribe to the VRTK_SDKManager on Awake in the class (see GameController.cs for example)
    public static VRTK_ControllerEvents LeftControllerEvents
    {
        get
        {
            if(leftControllerEvents == null)
            {
                leftControllerEvents = LeftController.GetComponent<VRTK_ControllerEvents>();
            }
            return leftControllerEvents;
        }
    }

    public static GameObject RightController
    {
        get
        {
            if (rightController == null)
            {
                rightController = VRTK_DeviceFinder.GetControllerRightHand();
            }

            return rightController;
        }
    }

    public static VRTK_ControllerEvents RightControllerEvents
    {
        get
        {
            if (rightControllerEvents == null)
            {
                rightControllerEvents = RightController.GetComponent<VRTK_ControllerEvents>();
            }

            return rightControllerEvents;
        }
    }
}
