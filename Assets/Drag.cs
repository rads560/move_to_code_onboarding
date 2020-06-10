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
    Boolean stillInContactWithOriginal;
    Boolean blockStillInMenu;

    public Console console;

    private MeshRenderer renderer;
    private MeshRenderer cloneRenderer;

    private void Awake()
    {
        startingPosition = transform.position;
        renderer = GetComponent<MeshRenderer>();
        manipulationHandler = GetComponent<ManipulationHandler>();
        manipulationHandler.OnManipulationStarted.AddListener(StartedMotion);
        manipulationHandler.OnManipulationEnded.AddListener(StoppedMotion);
        blockStillInMenu = true;
    }

    public void OnTriggerEnter()
    {
        stillInContactWithOriginal = true;
        if(cloneRenderer != null)
        {
            foreach (Material mat in cloneRenderer.materials)
            {
                mat.SetFloat("_Outline", 0.15f);
            }
        }
    }

    public void OnTriggerExit()
    {
        stillInContactWithOriginal = false;
        if (cloneRenderer != null)
        {
            foreach (Material mat in cloneRenderer.materials)
            {
                mat.SetFloat("_Outline", 0f);
            }
        }
        if (renderer != null)
        {
            foreach (Material mat in renderer.materials)
            {
                mat.SetFloat("_Outline", 0f);
            }
        }
    }
    
    private void StoppedMotion(ManipulationEventData arg0)
    {
        if (stillInContactWithOriginal)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.SetParent(console.transform);
            blockStillInMenu = false;
        }
        if (cloneRenderer != null)
        {
            foreach (Material mat in cloneRenderer.materials)
            {
                mat.SetFloat("_Outline", 0f);
            }
        }
        if (renderer != null)
        {
            foreach (Material mat in renderer.materials)
            {
                mat.SetFloat("_Outline", 0f);
            }
        }
    }

    private void StartedMotion(ManipulationEventData arg0)
    {
        if (blockStillInMenu)
        {
            clone = Instantiate(gameObject, startingPosition, Quaternion.identity); //  make a clone in original position
            clone.transform.SetParent(transform.parent);
            cloneRenderer = clone.GetComponent<MeshRenderer>();
        }
    }
}