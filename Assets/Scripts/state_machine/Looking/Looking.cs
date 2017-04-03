//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : State
{
    private LookingStateMachine lookStateMachine;
    private SeeingObject seeingObject;
    private Dictionary<string, StateID> states = new Dictionary<string, StateID>();

    private GameObject currentObject;
    private GameObject previousObject;

    private bool haveObject = false;
    private bool buttonClicked = false;

    private void Start()
    {
        lookStateMachine = gameObject.GetComponent<LookingStateMachine>();
        seeingObject = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SeeingObject>();
    }

    public void addTag(string str,StateID stateID)
    {
        states.Add(str, stateID);
    }
    
	public override void Act ()
    {
        currentObject = seeingObject.currentObject();

        if(currentObject != null || previousObject != null)
            checkObject();

        previousObject = currentObject;
    }
    	
	public override void Reason ()
    {
		if(haveObject && buttonClicked)
        {
            if (states.ContainsKey(currentObject.tag))
                lookStateMachine.setState(states[currentObject.tag]);
        }
	}

    public override void DoAction()
    {
        buttonClicked = true;
    }

    public override void StopAction()
    {
        buttonClicked = false;
    }

    public void checkObject()
    {
        if (previousObject != null && previousObject != currentObject)
        {
            if (previousObject.transform.childCount > 0)
                previousObject.transform.GetChild(0).gameObject.SetActive(false);

            haveObject = false;
        }

        if (currentObject != null && currentObject != previousObject)
        {          
            if (states.ContainsKey(currentObject.tag))
            {
                if(currentObject.transform.childCount > 0)
                    currentObject.transform.GetChild(0).gameObject.SetActive(true);

                haveObject = true;
            }           
        }       
    }
}
