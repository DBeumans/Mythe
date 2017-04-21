//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateID
{
    looking = 0,
    Inspect = 1,
    menu = 2,
    puzzle = 3
};

public class player : MonoBehaviour
{
    private LookingStateMachine lookingStateMachine;
    private Looking looking;

	void Start ()
    {
        lookingStateMachine = GetComponent<LookingStateMachine>();
        looking = GetComponent<Looking>();

        addStatesAndTags();

        lookingStateMachine.setState(StateID.looking);
    }
	
	private void addStatesAndTags ()
    {
        lookingStateMachine.addState(StateID.looking, looking);

        lookingStateMachine.addState(StateID.Inspect, GetComponent<Inspect>());
        looking.addTag(Tags.inspectable, StateID.Inspect);

        lookingStateMachine.addState(StateID.menu, GetComponent<MenuNavigation>());

        lookingStateMachine.addState(StateID.puzzle, GetComponent<PuzzleState>());
        looking.addTag(Tags.puzzle, StateID.puzzle);
	}
}
