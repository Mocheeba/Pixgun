using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }


    [SerializeField]
    private PlayerData PlayerData;
    #endregion
    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion
    #region Other variables
    public Vector2 CurrentVelocity { get; private set; }
    
    public int facingDirection {  get; private set; }
    private Vector2 workspace;

    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, PlayerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, PlayerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, PlayerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, PlayerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, PlayerData, "land");
    }

    private void Start()
    {
        facingDirection = 1;

        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();

    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion
    #region Set Functions
    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
       workspace.Set(CurrentVelocity.x, velocity);
       RB.velocity = workspace;
       CurrentVelocity = workspace;
    }    
    #endregion
    #region Check Functions
    public void CheckIfshouldFlip(int xInput)
    {
        if(xInput != 0 && xInput != facingDirection)
        {
            Flip();
        }
    }
    #endregion
#region Other Functions
    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion
}
