//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    public virtual void Enter()
    {
    }

    public virtual bool addPuzzlePiece(GameObject puzllePiece, GameObject puzzlePlace)
    {
        bool vallidPuzzlePiece = false;

        return vallidPuzzlePiece;
    }

    public virtual void getPuzzlePiece(GameObject puzllePiece,GameObject puzzlePlace)
    {

    }

    public virtual void Leave()
    {
    }
}
