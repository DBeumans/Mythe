//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPuzzle : Puzzle
{
    [SerializeField]
    private GameObject[] keys;

    [SerializeField]
    private GameObject[] values;

    private Dictionary<GameObject, GameObject> solution = new Dictionary<GameObject, GameObject>();

    private Dictionary<GameObject, GameObject> input = new Dictionary<GameObject, GameObject>();

    private PuzzleStateMachine puzzleMachine;

    private bool goodPiece = false;

    private void Start()
    {
        puzzleMachine = gameObject.GetComponent<PuzzleStateMachine>();

        if (keys.Length == values.Length)
        {
            for (int i = 0; i <= keys.Length - 1; i++)
            {
                solution.Add(keys[i], values[i]);
                input.Add(keys[i], null);
            }
        }
        else
        {
            Debug.LogError("keys and values are not the same size");
        }
    }

    public override void addPuzzlePiece(GameObject puzllePiece, GameObject puzzlePlace)
    {
        if (checkKeys(puzzlePlace) == true && checkValues(puzllePiece) == true)
        {
            goodPiece = true;
            input[puzzlePlace] = puzllePiece;
            
            if(checkSolution() == true)
            {   
                //geen tijd om het spel goed te maken dus het gaat maar naar het main menu
                Application.LoadLevel(0);
            }
        }
        else
        {
            goodPiece = false;
        }
    }

    public override void getPuzzlePiece(GameObject puzllePiece, GameObject puzzlePlace)
    {
        
    }

    public override bool goodPuzzlePiece()
    {

        return goodPiece;
    }

    private bool checkSolution()
    {
        foreach(var key in solution.Keys)
        {
            if(solution[key] != input[key])
            {
                return false;
            }
        }
        return true;
    }

    private bool checkKeys(GameObject puzzlePlace)
    {
        if(puzzlePlace != null)
        foreach(var key in solution.Keys)
        {
            if(key == puzzlePlace)
            {
                return true;
            }
        } 

        return false;
    }

    private bool checkValues(GameObject puzzlepiece)
    {
        if(puzzlepiece != null)
        foreach (var value in solution.Values)
        {
            if (value == puzzlepiece)
            {
                return true;
            }
        }

        return false;
    }
}
