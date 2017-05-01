//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleStateMachine : MonoBehaviour
{
    private Dictionary<PuzzleID, Puzzle> puzzles = new Dictionary<PuzzleID, Puzzle>();

    private Puzzle currentPuzzle;

    public Dictionary<PuzzleID, Puzzle> Puzzles
    {
        get
        {
            return puzzles;
        }

        set
        {
            puzzles = value;
        }
    }

    public void setState(PuzzleID puzzleID)
    {
        if (!puzzles.ContainsKey(puzzleID))
            return;

        if (currentPuzzle != null)
            currentPuzzle.Leave();

        currentPuzzle = puzzles[puzzleID];

        currentPuzzle.Enter();

    }

    public void addState(PuzzleID puzzleID, Puzzle state)
    {
        puzzles.Add(puzzleID, state);
    }
}
