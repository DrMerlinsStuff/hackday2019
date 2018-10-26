using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DisableAfterVideo : MonoBehaviour {

    public VideoPlayer vp;
    public GameObject nextVideo;
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
        nextVideo.SetActive(true);
    }

}
