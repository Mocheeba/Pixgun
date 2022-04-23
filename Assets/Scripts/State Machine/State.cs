using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;

    protected string aniBoolName;

    protected float startTime; // when enemy enter the state

    public State(Entity entity, FiniteStateMachine StateMachine, string aniBoolName)
    {
        this.aniBoolName = aniBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(aniBoolName, true);
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(aniBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}