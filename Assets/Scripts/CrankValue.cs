using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CrankValue : MonoBehaviour
{

    public VRTK_Knob knob;
    public GameObject jack;
    public Vector3 growSize;
    float currentValue = 0;

	// Use this for initialization
	void Start ()
	{
	    knob.ValueChanged += delegate { OnValueChanged(); };
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void OnValueChanged()
    {
        var maxValue = 1000;

        if (currentValue / maxValue < 1 && currentValue++ < maxValue)
        {
            jack.transform.localScale += growSize;
        }
        else
        {
            return;
        }


        //Debug.unityLogger.Log(knob.GetValue());
        Debug.unityLogger.Log(currentValue / maxValue);
        //Debug.unityLogger.Log(jack.transform.localScale);
    }
}
