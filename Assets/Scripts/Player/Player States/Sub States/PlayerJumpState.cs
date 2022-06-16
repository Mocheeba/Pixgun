using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int amountOfJumpsLeft;
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    } 

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseJumpInput();
        core.Movement.SetVelocityY(playerData.jumpVelocity);
        isAbilityDone = true;
        amountOfJumpsLeft--;
        player.InAirState.SetIsJumping();
    }

    public bool CanJump()
    {
        if (DialogueMenager.isActive == true)
            return false;

        else if (amountOfJumpsLeft > 0)
        {
            return true;
        }    
        else
        {
            return false;
        }    
    }

    public void canAttack()
    {
       if (Input.GetMouseButton(0)) 
       Debug.Log("Attack?"); 
    }

    public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = playerData.amountOfJumps;

    public void DecreaseAmountOfJumpLeft() => amountOfJumpsLeft--;

}
