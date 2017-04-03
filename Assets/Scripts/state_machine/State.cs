//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public virtual void Enter()
    {
    }

    public virtual void DoAction()
    {
    }

    public virtual void StopAction()
    {
    }

    public abstract void Act();

    public abstract void Reason();

    public virtual void Leave()
    {
    }
}

