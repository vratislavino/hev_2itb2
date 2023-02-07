using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    NavMeshAgent agent;
    StaticSymbol symbol;

    public override void InitState() {
        state = StateEnum.Attack;
        agent = GetComponent<NavMeshAgent>();
        symbol = GetComponent<StaticSymbol>();
    }

    public override void DoStep() {
        SymbolEnum enemy = symbol.Symbol;
        if(DataHolder.Instance.Player.WouldEnemyWin(enemy)) {
            agent.SetDestination(DataHolder.Instance.Player.transform.position);
        } else {
            var dir = DataHolder.Instance.Player.transform.position - transform.position;
            dir.y = 0;
            agent.SetDestination(transform.position - dir);
        }

        // vyhrál by enemy?

    }

    public override StateEnum TryToChangeState() {
        if (Vector3.Distance(transform.position, DataHolder.Instance.Player.transform.position) < 10) {
            if (DataHolder.Instance.Player.Symbol == symbol.Symbol)
                return StateEnum.Idle;
            return StateEnum.Attack;
        } else {
            return StateEnum.Idle;
        }
    }
}
