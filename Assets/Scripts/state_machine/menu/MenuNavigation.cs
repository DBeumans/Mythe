//Brian Boersen
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : State
{
    private LookingStateMachine lookAtateMachine;
    private SeeingObject look;

    private GameObject level;
    private GameObject menu;

    private GameObject currentButton, 
                       previousButton;

    private bool levelState = true;

    private void Start()
    {
        lookAtateMachine = GetComponent<LookingStateMachine>();
        look = GetComponent<SeeingObject>();
        getLevel();
        getMenu();
    }

    private void getLevel()
    {
        if (GameObject.FindGameObjectWithTag(Tags.level) != null)
        {
            level = GameObject.FindGameObjectWithTag(Tags.level);
            levelState = level.activeSelf;
        }            
        else
            Debug.LogError("give the whole level map the tag Level");
    }

    private void getMenu()
    {
        if (GameObject.FindGameObjectWithTag(Tags.menu) != null)
        {
            menu = GameObject.FindGameObjectWithTag(Tags.menu);
            menu.SetActive(false);
        }
        else
            Debug.LogError("give the whole menu map the tag Level");
    }

    public override void Enter()
    {
        levelSwitch();
    }

    public override void Act()
    {
        currentButton = look.getCurrentSeeingObject();

        if(currentButton.tag == Tags.button)
        {
            setHovering();
        }

        previousButton = currentButton;
    }

    public override void Reason()
    {
        
    }

    private void setHovering()
    {

    }

    private void levelSwitch()
    {
        levelState = !levelState;
        level.SetActive(levelState); 
        menu.SetActive(!levelState);
    }

    public override void DoAction1()
    { 
        
    }

    public override void doAction2()
    {
        lookAtateMachine.setState(StateID.looking);
    }

    public override void Leave()
    {
        levelSwitch();
    }
}
