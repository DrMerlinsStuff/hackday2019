using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DoughSwitcher : MonoBehaviour
{

    public int doughIndex = 0;
    public GameObject[] doughs = new GameObject[4];
    VRTK_InteractableObject v_io;
    public bool wasGrabbed;
    public bool canChange = false;

    // Use this for initialization
    void Start()
    {
        TurnOnADough();
        v_io = GetComponent<VRTK_InteractableObject>();
    }

    void TurnOnADough()
    {
        Debug.LogError("This is a dough " + doughIndex);
        foreach (GameObject go in doughs)
            go.SetActive(false);

        doughs[doughIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (wasGrabbed & !v_io.IsGrabbed()) //have just thrown it        
            canChange = true;
        
        wasGrabbed = v_io.IsGrabbed();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canChange && other.name == "DoughSwitchingTrigger")
        {
            if (doughIndex < doughs.Length - 1)
                doughIndex++;
            canChange = false;
            TurnOnADough();
        }
    }
}
