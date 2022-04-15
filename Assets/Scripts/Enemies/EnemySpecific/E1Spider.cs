using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Spider : Entity
{
    public E1Spider_IdleState idleState { get; private set; }
    public E1Spider_MoveState moveState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;

    public override void Start()
    {
        base.Start();

        moveState = new E1Spider_MoveState(this, stateMachine, "move", moveStateData, this);


    }

}
