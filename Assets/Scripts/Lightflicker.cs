using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightflicker : MonoBehaviour {

    public float min_intensity = .2f;
    public float max_intensity = 1f;  

    public float intensity;
    bool direction = true;
    Light me;

    // Use this for initialization
    void Start()
    {
        //intensity = Random.Range(min_intensity, max_intensity);
        me = GetComponent<Light>();
    }
    // Update is called once per frame
    void Update ()
    {
        if (direction)
            intensity += Time.deltaTime * 2;
        else
            intensity -= Time.deltaTime * 2;
        if (intensity > max_intensity)
            direction = false;
        else if (intensity < min_intensity)
            direction = true;
        me.intensity = intensity;
    }
}
