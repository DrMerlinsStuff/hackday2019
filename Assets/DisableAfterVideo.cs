using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DisableAfterVideo : MonoBehaviour {

    public VideoPlayer vp;
	// Use this for initialization
	void Start () {
        vp.loopPointReached += Disable;
	}

    // Update is called once per frame
    void Update() {

    }

    void Disable(UnityEngine.Video.VideoPlayer vp)
    {
        gameObject.SetActive(false);
    }

}
