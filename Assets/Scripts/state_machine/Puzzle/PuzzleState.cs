﻿//Brian Boersen
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleState : State
{
    private LookingStateMachine lookingStateMachine;
    private Looking looking;
    private InventoryUI inventoryUI;

    private GameObject puzzleObject;

    [SerializeField]
    private GameObject puzzleMenu;

    private void Start()
    {
        if(puzzleMenu == null)
        {
            Debug.LogError("no puzzle menu atached");
        }

        lookingStateMachine = GetComponent<LookingStateMachine>();
        looking = GetComponent<Looking>();
        inventoryUI = GetComponent<InventoryUI>();
    }

    public override void Enter()
    {
        if (looking.CurrentObject != null)
        {
            puzzleObject = looking.CurrentObject;
            puzzleObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("missing current object");
        }
    }

    public override void Act()
    {
        
    }

    public override void Reason()
    {
        
    }

    public override void DoAction1()
    {
        base.DoAction1();
    }

    public override void StopAction1()
    {
        base.StopAction1();
    }

    public override void DoAction2()
    {
        lookingStateMachine.setState(StateID.looking);
    }   
}
