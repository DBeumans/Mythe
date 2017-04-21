//Brian Boersen
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : State
{
    private enum ButtenStates
    {
        enterButton = 0,
        onButton = 1,
        exitButton = 2,
        ofButton = 3

    }

    private ButtenStates buttonstate;

    private LookingStateMachine lookAtateMachine;
    private SeeingObject look;
    private ObjectPlacer placer;

    private GameObject level;
    private GameObject menu;

    private GameObject button,previousButton;
    private VrButton vrButton;

    private bool levelState = true;

    private void Start()
    {
        buttonstate = ButtenStates.ofButton;
        lookAtateMachine = GetComponent<LookingStateMachine>();
        look = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<SeeingObject>();
        placer = GetComponent<ObjectPlacer>();
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
        placer.placeInfrontOfCamera(menu, 3f,true,true);
    }

    public override void Act()
    {
        button = look.getCurrentSeeingObject();
        checkButton();
        previousButton = button;
    }

    public override void Reason()
    {
        
    }

    private void setHovering(bool hoverState)
    {
        vrButton.setHover(hoverState);
    }

    private void checkButton()
    {
        switch (buttonstate)
        {
            case ButtenStates.ofButton:
                if(button != null)
                {
                    if (button.tag == Tags.button)
                    {
                        if (button.GetComponent<VrButton>() != null)
                        {
                            vrButton = button.GetComponent<VrButton>();
                            buttonstate = ButtenStates.enterButton;
                        }
                    }
                }
                break;
            case ButtenStates.enterButton:
                setHovering(true);
                buttonstate = ButtenStates.onButton;
                break;
            case ButtenStates.onButton:
                if(button != previousButton)
                {
                    buttonstate = ButtenStates.exitButton;
                }
                break;
            case ButtenStates.exitButton:
                setHovering(false);
                buttonstate = ButtenStates.ofButton;
                break;
        }
    }

    private void levelSwitch()
    {
        levelState = !levelState;
        level.SetActive(levelState); 
        menu.SetActive(!levelState);
    }

    public override void DoAction1()
    {
        if (buttonstate == ButtenStates.onButton)
        {
            vrButton.clicked();
        }
    }

    public override void DoAction2()
    {
        lookAtateMachine.setState(StateID.looking);
    }

    public override void Leave()
    {
        levelSwitch();
    }
}
