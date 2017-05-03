//Brian Boersen
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspect : State
{
    private Looking looking;
    private LookingStateMachine lookingStateMachine;
    private ObjectPlacer placer;
    private InventoryUI inventoryUI;

    private GameObject inspectingObject;

    private Vector3 oldPosition;

   

    private void Start()
    {
        looking = GetComponent<Looking>();
        lookingStateMachine = GetComponent<LookingStateMachine>();
        placer = GetComponent<ObjectPlacer>();
        inventoryUI = GetComponent<InventoryUI>();
    }
    
    public override void Enter()
    {
        if(looking.CurrentObject != null)
        {
            inspectingObject = looking.CurrentObject;
            inspectObject();          
        }
        else
        {
            Debug.LogError("missing current object");
        }
        
    }

    public override void DoAction1()
    {
        lookingStateMachine.setState(StateID.looking);
    }

    private void inspectObject()
    {
        oldPosition = inspectingObject.transform.position;
        placer.placeInfrontOfCamera(inspectingObject, 3f);
        setTurnOn();
        inventoryUI.AddItemByName(inspectingObject.name);
    }

    public override void Leave()
    {
        if (inspectingObject.tag == Tags.inspectable)
        {
            putBack();
            setTurnOf();
        }
        inspectingObject = null;
    }

    private void putBack()
    {
        placer.placeBack(inspectingObject,oldPosition);
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
