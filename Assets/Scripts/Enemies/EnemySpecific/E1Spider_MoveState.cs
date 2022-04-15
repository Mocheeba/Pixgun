using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Spider_MoveState : MoveState
{
    private E1Spider enemy;

    public E1Spider_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, E1Spider enemy ) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isDetectingLedge || isDetectingLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
