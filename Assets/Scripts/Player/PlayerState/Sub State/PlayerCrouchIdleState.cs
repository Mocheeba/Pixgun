using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerGroundedState
{
    public PlayerCrouchIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }


    public override void Enter()
    {
        base.Enter();

        core.Movement.SetVelocityZero();
        player.SetColliderHeight(playerData.crouchColliderHeight);
        Debug.Log("player Crouch Idle Enter");

    }

    public override void Exit()
    {
        base.Exit();
        player.SetColliderHeight(playerData.standColliderHeight);
        Debug.Log("player Crouch Idle Exit");
    }

    public override void LogicUpdate()

    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (xInput != 0 )
            {
                stateMachine.ChangeState(player.CrouchMoveState);
            }
            else if(yInput != -1 && !isTouchingCeiling)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}
