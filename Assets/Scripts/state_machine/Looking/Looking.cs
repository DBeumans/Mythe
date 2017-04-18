//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : State
{
    private LookingStateMachine lookStateMachine;
    private SeeingObject sight;
    private Dictionary<string, StateID> states = new Dictionary<string, StateID>();

    private GameObject currentObject;
    private GameObject previousObject;

    private bool haveObject = false;

    public GameObject CurrentObject
    {
        get { return currentObject; }
    }

    private void Start()
    {
        lookStateMachine = gameObject.GetComponent<LookingStateMachine>();
        sight = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SeeingObject>();
    }

    public void addTag(string str,StateID stateID)
    {
        states.Add(str, stateID);
    }
    
	public override void Act ()
    {
        currentObject = sight.getCurrentSeeingObject();

        if(currentObject != null || previousObject != null)
            checkObject();

        previousObject = currentObject;
    }
    
	public override void Reason (){}

    public override void DoAction1()
    {
        if (haveObject)
        { 
            if (states.ContainsKey(currentObject.tag))
            {
                lookStateMachine.setState(states[currentObject.tag]);
            }              
        }
    }

    public override void DoAction2()
    {
        lookStateMachine.setState(StateID.menu);
    }

    private void checkObject()
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
                if(currentObject.transform.childCount > 0 && currentObject.tag != Tags.puzzle)
                    currentObject.transform.GetChild(0).gameObject.SetActive(true);

                haveObject = true;
            }           
        }       
    }

    public override void Leave()
    {       
        previousObject = null;

        if(currentObject != null)
        if (currentObject.transform.childCount > 0)
            currentObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
