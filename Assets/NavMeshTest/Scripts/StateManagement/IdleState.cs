using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    NavMeshAgent agent;
    Vector3 targetPoint;

    Vector3 lastPosition;
    Quaternion lastRotation;

    public override void InitState() {
        state = StateEnum.Idle;
        agent = GetComponent<NavMeshAgent>();
        SendEnemy();
    }
 
    private void SendEnemy() {
        targetPoint = GeneratePoint();
        agent.SetDestination(targetPoint);
    }

    private Vector3 GeneratePoint() {
        return new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
    }

    public override void DoStep() {
        var playerPos = transform.position;
        playerPos.y = 0;

        if(Vector3.Distance(playerPos, targetPoint) < 1 || IsNotMoving()) {
            SendEnemy();
        }

        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    private bool IsNotMoving() {
        return Vector3.Distance(transform.position, lastPosition) < 0.00001f
            && Quaternion.Angle(transform.rotation, lastRotation) < 0.00001f;
    }

    public override StateEnum TryToChangeState() {
        // pokud jsi blízko hráèe, vra StateEnum.Attack

        return StateEnum.Idle;
    }
}
