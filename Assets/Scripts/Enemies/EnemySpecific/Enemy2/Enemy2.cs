using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
  public E2_IdleState idleState { get; private set; }
  public E2_MoveState moveState { get; private set; }

  [SerializeField]
  private D_MoveState moveStateData;
  [SerializeField]
  private D_IdleState idleStateData;

  
  public override void Start()
  {
        base.Start();

        moveState = new E2_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E2_IdleState(this, stateMachine, "idle", idleStateData, this);

        stateMachine.Initialize(moveState);
  }

     public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

    }

}
