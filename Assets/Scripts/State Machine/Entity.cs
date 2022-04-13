using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public D_Entity entityData;

    public int facingDirection { get; private set; }
    // all enemies will inharate from this class.
    public RigidBody2D rb { get; private set; } // reference from our state, set it in enemy class
    public Animator anim { get; private set; }
    public GameObject aliveGO { get; private set; }
    
    [SerializedField]
    private Transform wallCheck;

    [SerializedField]
    private Transform ledgeCheck;

    public Vector2 velocityWorkSpace;

    public virtual void Start()
    {
        aliveGO = transform.Find("Alive").gameObject;
        rb = aliveGO.GetComponent<RigidBody2D>();
        anim = aliveGO.GetComponent<Animator>();

        stateMachine = new FiniteStateMachine();

    }

    public virtual void Update()
    {
        StateMachine.current.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate()
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkSpace.Set(facingDirection * velocity, rb.velocity.y)
        rb.velocity = velocityWorkSpace;
    }



    public virtual void CheckWall()
    {
        return Physics2D.Reycast(wallCheck.position, aliveGO.transform.right, EntityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual void CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.dowm, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

}
