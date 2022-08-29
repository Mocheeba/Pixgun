using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Entity entityData;

    public int facingDirection {get; private set; }

    public Rigidbody2D rb { get; private set; }

    public Animator anim { get; private set; }

    public GameObject aliveGO { get; private set; }

    public Vector2 velocityWorkspace {get; private set; } // create Vector2 t

    #region Checks
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    #endregion

    public virtual void Start()
    {
        aliveGO = transform.Find("Alive").gameObject; // take reference from Hierarchy

        rb = aliveGO.GetComponent<Rigidbody2D>();

        anim = aliveGO.GetComponent<Animator>();
        
        stateMachine = new FiniteStateMachine();

    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void PhysicsUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity) // set the velocity on the enemy base on faceDirection and inputVelocity 
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
            //position, distance, what we checking for
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0f);
    }

}
