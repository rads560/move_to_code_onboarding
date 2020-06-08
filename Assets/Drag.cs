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
    Boolean enableFlag;

    public Console console;

    private MeshRenderer renderer;
    private MeshRenderer clone_renderer;

    private void Awake()
    {
        startingPosition = transform.position;
        renderer = GetComponent<MeshRenderer>();
        manipulationHandler = GetComponent<ManipulationHandler>();
        manipulationHandler.OnManipulationStarted.AddListener(StartedMotion);
        manipulationHandler.OnManipulationEnded.AddListener(StoppedMotion);
        enableFlag = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        triggerFlag = true;
        if(clone_renderer != null)
        {
            foreach (var mat in clone_renderer.materials)
            {
                mat.SetFloat("_Outline", 0.15f);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        triggerFlag = false;
        if (clone_renderer != null)
        {
            foreach (var mat in clone_renderer.materials)
            {
                mat.SetFloat("_Outline", 0f);
            }
        }
        if (renderer != null)
        {
            foreach (var mat in renderer.materials)
            {
                mat.SetFloat("_Outline", 0f);
            }
        }
    }
    
    private void StoppedMotion(ManipulationEventData arg0)
    {
        if (triggerFlag) // if we are touching the original item
        {
            Destroy(gameObject); // delete the extra block
        }
        else
        {
            transform.parent = console.transform;
            gameObject.GetComponent<Drag>().enabled = false;
            enableFlag = false;
        }
        if (clone_renderer != null)
        {
            foreach (var mat in clone_renderer.materials)
            {
                mat.SetFloat("_Outline", 0f);
            }
        }
        if (renderer != null)
        {
            foreach (var mat in renderer.materials)
            {
                mat.SetFloat("_Outline", 0f);
            }
        }
    }

    private void StartedMotion(ManipulationEventData arg0)
    {
        if(enableFlag == true)
        {
            clone = Instantiate(gameObject, startingPosition, Quaternion.identity); //  make a clone in original position
            clone.transform.SetParent(transform.parent);
            clone_renderer = clone.GetComponent<MeshRenderer>();
        }
    }
}