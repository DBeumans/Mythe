//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public virtual void Enter()
    {
    }

    public virtual void DoAction1()
    {
    }

    public virtual void doAction2()
    {
    }

    public abstract void Act();

    public abstract void Reason();

    public virtual void Leave()
    {
    }
}

