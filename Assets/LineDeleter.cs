using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class LineDeleter : MonoBehaviour
{

    public VRTK_ControllerEvents controller;
    bool isAlreadyPainting = false;
    LineRenderer currentLine;
    int linepointcount;
    List<GameObject> paintGameObjectContainer;


    // Start is called before the first frame update
    void Start()
    {
        VRTK_ControllerEvents controller = GetComponentInChildren<VRTK_ControllerEvents>();
        LineRenderer lineRenderer = new LineRenderer();
        paintGameObjectContainer = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null)
            controller = GetComponentInChildren<VRTK_ControllerEvents>();
        if (controller.buttonOnePressed)
        {
            Debug.LogError("got here");
            if (!isAlreadyPainting)
            {
                GameObject go = new GameObject("paint");
                paintGameObjectContainer.Add(go);
                currentLine = go.AddComponent<LineRenderer>();
                linepointcount = 0;
                isAlreadyPainting = true;
            }
            currentLine.positionCount = linepointcount + 1;
            currentLine.SetPosition(linepointcount, controller.transform.position);
            linepointcount++;
            currentLine.startWidth = .05f;
            currentLine.endWidth = .05f;
        }
        else
        {
            isAlreadyPainting = false;
        }



    }

}


