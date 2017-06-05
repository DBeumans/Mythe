//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    public virtual void Enter()
    {

    }

    public virtual void addPuzzlePiece(GameObject puzllePiece, GameObject puzzlePlace)
    {

    }

    public virtual bool goodPuzzlePiece()
    {
        return false;
    }

    public virtual void getPuzzlePiece(GameObject puzllePiece,GameObject puzzlePlace)
    {

    }

    public virtual void Leave()
    {

    }
}
