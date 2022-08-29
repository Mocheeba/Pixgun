using System.Collections;
using System.Collections.Generic;
using UnityEngine;

pubic class E1_MoveState : MoveState
{

    private Enemy1 enemy; 

    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy1 enemy): base(entity, stateMachine, animBoolName)
    {
        this.Enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter(); // we can remove so base its not called 

      
    }

    public override void Exit()
    {
        base.Exit(); 
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate(); 

        if(isDetectingWall || !isDetectingLedge)
        {
            //TODO: setup
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate(); 

        
    }


}
