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
    public float currentValue = 0;
    public float percent = 0f;
    public Animator jackAnim;
    public Animator carAnimator;
    public AudioSource audioSource;

    float oldPercent =0f;


	// Use this for initialization
	void Start ()
	{
	    knob.ValueChanged += delegate { OnValueChanged(); };
	}
	
	// Update is called once per frame
	void Update () {
        jackAnim.Play("ScrewUpDown", 0, percent);
        carAnimator.Play("carGoUp",0, percent);
        if (percent > oldPercent + .03f)
        {
            oldPercent = percent;
            audioSource.Play();
        }

    }



    public void OnValueChanged()
    {
        var maxValue = 1000;

        percent = currentValue / maxValue;
        if (percent < 1 && currentValue++ < maxValue)
        {            
            //jack.transform.localScale += growSize;           
            //Debug.LogError("float " + percent);
        }
        else
        {            
            return;
        }
      
        Debug.unityLogger.Log(currentValue / maxValue);
    }
}
