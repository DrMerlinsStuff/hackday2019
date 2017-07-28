using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRTK;

public class DoughSwitcher : MonoBehaviour
{
    public Texture sauce;

    public int doughIndex = 0;
    public GameObject[] doughs = new GameObject[4];
    VRTK_InteractableObject v_io;
    public bool wasGrabbed;
    public bool canChange = false;

    // Use this for initialization
    void Start()
    {
        v_io = GetComponent<VRTK_InteractableObject>();
    }

    void TurnOnADough()
    {
        doughs[doughIndex].SetActive(false);
        doughIndex++;
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
        if (!canChange || doughIndex >= doughs.Length - 1)
            return;

        if (other.name == "DoughSwitchingTrigger")
        {
            TurnOnADough();
            canChange = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("sauce") && doughIndex == 3)
        {
            var children = gameObject.GetComponentsInChildren(typeof(MeshRenderer), true).Select(c => c as MeshRenderer).ToList();
            children.Single(s => s.CompareTag("topping_sauce")).enabled = true;
            collision.collider.gameObject.transform.position = new Vector3(50, 0, 0);
        }
    }
}
