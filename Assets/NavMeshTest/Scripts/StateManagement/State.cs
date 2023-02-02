using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    // state by si mohl pamatovat svùj StateEnum :)

    public abstract void InitState();

    public abstract void DoStep();

    public abstract StateEnum TryToChangeState();
}

public enum StateEnum
{
    Idle, Attack
}
