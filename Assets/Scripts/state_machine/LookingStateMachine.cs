//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingStateMachine : MonoBehaviour
{

    private Dictionary<StateID,State> states = new Dictionary<StateID,State>();
    private State currentState;
        	
    void Update ()
    {
        if(currentState != null)
        {
            currentState.Act();
            currentState.Reason();
        }
	}

    public void doAction()
    {
        if (currentState != null)
            currentState.DoAction();
    }

    public void stopAcktion()
    {
        if (currentState != null)
            currentState.StopAction();
    }

    public void setState(StateID stateID)
    {
        if (!states.ContainsKey(stateID))
            return;

        if (currentState != null)
            currentState.Leave();

        currentState = states[stateID];

        currentState.Enter();

    }

    public void addState(StateID stateID, State state)
    {
        states.Add(stateID, state);
    }
}
