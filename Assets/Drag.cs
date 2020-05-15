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
    Boolean triggerFlag;

    private void Awake()
    {
        startingPosition = transform.position;
        manipulationHandler = GetComponent<ManipulationHandler>();
        manipulationHandler.OnManipulationStarted.AddListener(StartedMotion);
        manipulationHandler.OnManipulationEnded.AddListener(StoppedMotion);
    }

    public void OnTriggerEnter(Collider other)
    {
        triggerFlag = true;
    }

    public void OnTriggerExit(Collider other)
    {
        triggerFlag = false;
    }
    
    private void StoppedMotion(ManipulationEventData arg0)
    {
        if (triggerFlag) // if we are touching the original item
        {
            Destroy(gameObject); // delete the extra block
        }

    }

    private void StartedMotion(ManipulationEventData arg0)
    {
        clone = Instantiate(gameObject, startingPosition, Quaternion.identity); //  make a clone in original position
    }
}