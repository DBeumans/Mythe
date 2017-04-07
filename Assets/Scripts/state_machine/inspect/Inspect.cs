﻿//Brian Boersen
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspect : State
{
    private Looking looking;
    private LookingStateMachine lookingStateMachine;

    private GameObject inspectingObject;
    private GameObject parrentObject;

    private Vector3 oldPosition;

    private void Start()
    {
        looking = GetComponent<Looking>();
        lookingStateMachine = GetComponent<LookingStateMachine>();
    }
    
    public override void Enter()
    {
        if(looking.CurrentObject != null)
        {
            inspectingObject = looking.CurrentObject;
            separateParrent();
            inspectObject();
        }
        else
        {
            Debug.LogError("missing current object");
        }
        
    }

    public override void DoAction()
    {
        if(inspectingObject.tag == Tags.inspectable)
        {
            putBack();

            if (parrentObject != null)
            {
                putInParrent();
            }

            setTurnOf();
        }
        else if(inspectingObject.tag == Tags.special)
        {

        }

        lookingStateMachine.setState(StateID.looking);
    }

    private void separateParrent()
    {
        if(inspectingObject.transform.parent.gameObject != null)
        {
            parrentObject = inspectingObject.transform.parent.gameObject;
            inspectingObject.transform.parent = null;
        }
    }

    private void inspectObject()
    {
        GameObject cam = GameObject.FindGameObjectWithTag(Tags.mainCamera);
        oldPosition = inspectingObject.transform.position;
        print(GameObject.FindGameObjectWithTag(Tags.mainCamera).transform.forward);
        inspectingObject.transform.position = cam.transform.position + (cam.transform.forward * 3) ;
        setTurnOn();
    }

    public override void Leave()
    {
        inspectingObject = null;
        parrentObject = null;
    }

    private void putInParrent()
    {
        inspectingObject.transform.parent = parrentObject.transform;
    }

    private void putBack()
    {
        inspectingObject.transform.position = oldPosition;
    }

    private void setTurnOn()
    {

    }

    private void setTurnOf()
    {

    }

    public override void Act()
    {

    }

    public override void Reason()
    {

    }
}
