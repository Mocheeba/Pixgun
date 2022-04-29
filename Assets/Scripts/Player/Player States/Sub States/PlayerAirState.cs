using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private int xInput;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingWallBack;
    private bool oldIsTouchingWall;
    private bool oldIsTouchingWallBack;
    private bool jumpInput;
    private bool jumpInputStop;
    private bool caoyteTime;
    private bool wallJumpCaoyteTime;
    private bool isJumping;
    private bool grabInput;

    private float startWallJumpCaoyteTime;
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        oldIsTouchingWall = isTouchingWall;
        oldIsTouchingWallBack = isTouchingWallBack;

        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
        isTouchingWallBack = player.CheckIfTouchingWallBack();

        if(!wallJumpCaoyteTime && !isTouchingWall && !isTouchingWallBack && (oldIsTouchingWall || oldIsTouchingWallBack))
         {
            StartWallJumpCaoyteTime();
         }

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

        CheckCoyoteTime();
        CheckWallJumpCaoyteTime();

        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        jumpInputStop = player.InputHandler.JumpInputStop;
        grabInput = player.InputHandler.GrabInput;

        CheckJumpMultiplier();

        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            player.CheckIfshouldFlip(xInput);
            stateMachine.ChangeState(player.LandState);
        }
        else if(jumpInput && (isTouchingWall || isTouchingWallBack || wallJumpCaoyteTime))
        {
            StopWallJumpCaoyteTime();
            isTouchingWall = player.CheckIfTouchingWall();
            player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }

        else if(jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if(isTouchingWall && grabInput)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        else if(isTouchingWall && xInput == player.facingDirection && player.CurrentVelocity.y <= 0)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
        else
        {
            player.CheckIfshouldFlip(xInput);
            player.SetVelocityX(playerData.movementVelocity * xInput);

            player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));
        }
    }

    private void CheckJumpMultiplier()
    {

        if (isJumping)
        {
            if (jumpInputStop)
            {
                player.SetVelocityY(player.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if (player.CurrentVelocity.y <= 0.0f)
            {
                isJumping = false;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckCoyoteTime()
    {
        if(caoyteTime && Time.time > startTime + playerData.caoyteTime)
        {
            caoyteTime = false;
            player.JumpState.DecreaseAmountOfJumpLeft();
        }
    }

    private void CheckWallJumpCaoyteTime()
    {
        if(wallJumpCaoyteTime && Time.time > startWallJumpCaoyteTime + playerData.caoyteTime)
        {
            wallJumpCaoyteTime = false;
        }
    }

    public void StartCoyoteTime() => caoyteTime = true;

    public void StartWallJumpCaoyteTime()
    {
        wallJumpCaoyteTime = true;
        startWallJumpCaoyteTime = Time.time;
    }

    public void StopWallJumpCaoyteTime() => wallJumpCaoyteTime = false;

    public void SetIsJumping() => isJumping = true;
}
