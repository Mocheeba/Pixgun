using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{
    private int WallJumpDirection;
    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
        player.SetVolocity(playerData.wallJumpVelocity, playerData.wallJumpAngle, WallJumpDirection);
        player.CheckIfshouldFlip(WallJumpDirection);
        player.JumpState.DecreaseAmountOfJumpLeft(); 
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
        player.Anim.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));

        if(Time.time >= startTime + playerData.WallJumpTime)
        {
            isAbilityDone = true; 
        }
    }

    public void DetermineWallJumpDirection(bool isTouchingWall)
    {
        if(isTouchingWall)
        {
            WallJumpDirection = -player.facingDirection;
        }
        else
        {
            WallJumpDirection = player.facingDirection;
        }
    }
}
