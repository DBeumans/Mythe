//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateID
{
    looking = 0,
    Inspect = 1
};

public class player : MonoBehaviour
{
    private LookingStateMachine lookingStateMachine;
    private Looking looking;

	void Start ()
    {
        lookingStateMachine = GetComponent<LookingStateMachine>();
        looking = GetComponent<Looking>();

        addTatesAndTags();

        lookingStateMachine.setState(StateID.looking);
    }
	
	private void addTatesAndTags ()
    {
        lookingStateMachine.addState(StateID.looking, looking);

        lookingStateMachine.addState(StateID.Inspect, GetComponent<Inspect>());
        looking.addTag(Tags.inspectable, StateID.Inspect);
	}
}
