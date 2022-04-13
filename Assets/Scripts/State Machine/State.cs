using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine;
    protected entity

    protected string aniBoolName;

    protected float startTime; // when enemy enter the state

    public State(Entity etity, FiniteStateMachine StateMachine, string aniBoolName)
    {
        this.entity = entity;
        this.entity = stateMachine;
        this.stateMachine = etity;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(aniBoolName, true);
    }

    public virtual Exit()
    {
        entity.anim.SetBool(aniBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate()
    {

    }
}