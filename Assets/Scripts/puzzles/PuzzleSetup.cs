using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PuzzleID
{
    paintingPuzzle = 0
}

public class PuzzleSetup : MonoBehaviour
{
    private PuzzleStateMachine puzzleStateMachine;

    void Start ()
    {
        puzzleStateMachine = GetComponent<PuzzleStateMachine>();

        addPuzzles();

        puzzleStateMachine.setState(PuzzleID.paintingPuzzle);
	}
	
	void addPuzzles ()
    {
        //puzzleStateMachine.addState(PuzzleID.paintingPuzzle, );
	}
}
