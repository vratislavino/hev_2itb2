using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{

    protected StateEnum state;
    public StateEnum StateEnum => state;

    public abstract void InitState();

    public abstract void DoStep();

    public abstract StateEnum TryToChangeState();
}

public enum StateEnum
{
    Idle, Attack
}
