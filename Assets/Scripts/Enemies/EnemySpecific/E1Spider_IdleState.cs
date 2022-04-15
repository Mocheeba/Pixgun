using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Spider_IdleState : IdleState
{
    private E1Spider enemy;

    public E1Spider_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolname, D_IdleState stateData, E1Spider enemy) : base(entity, stateMachine, animBoolname, stateData)
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

        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
