using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private State currentState;
    public State CurrentState => currentState;

    void Start()
    {
        currentState = gameObject.AddComponent<IdleState>();
        currentState.InitState();
    }

    void Update()
    {
        currentState.DoStep();
        var newState = currentState.TryToChangeState();
        if(newState != currentState.StateEnum) {
            Destroy(currentState);
            switch(newState) {
                case StateEnum.Attack:
                    currentState = gameObject.AddComponent<AttackState>();
                    break;
                case StateEnum.Idle:
                    currentState = gameObject.AddComponent<IdleState>();
                break;
            }
            currentState.InitState();
        }
    }
}
