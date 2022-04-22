using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;


    protected float startTime;

    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }
// virtual is used when function can be overriten by class that's inherit from this class.
    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        Debug.Log(animBoolName);
    }

    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }
    
   
    public virtual void LogicUpdate() // Call every frame 
    {

    }

    public virtual void PhysicsUpdate() // call every PhysicsUpdate
    {
        DoChecks();
    }

    public virtual void DoChecks() // look for ground, walls 
    {

    }

}
