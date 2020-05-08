using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class Drag : MonoBehaviour
{
    ManipulationHandler manipulationHandler;
    Vector3 startingPosition;
    GameObject clone;

    private void Awake()
    {
        //Debug.Log("running awake");
        startingPosition = transform.position;
        manipulationHandler = GetComponent<ManipulationHandler>();
        manipulationHandler.OnManipulationStarted.AddListener(startedMotion);
        manipulationHandler.OnManipulationEnded.AddListener(stoppedMotion);
    }

    private void stoppedMotion(ManipulationEventData arg0)
    {
        if (Vector3.Distance(transform.position, startingPosition) < 2) // how far you can move the block while it still will snap back
        {
            Destroy(this.gameObject);
        }

    }

    public void startedMotion(ManipulationEventData arg0)
    {
        //Debug.Log("started motion");
        if (Vector3.Distance(transform.position, startingPosition) < 1)
        {
            clone = Instantiate(this.gameObject, startingPosition, Quaternion.identity); //  make a clone in original position
            //Debug.Log("clones start: " + startingPosition);
        }
    }
}