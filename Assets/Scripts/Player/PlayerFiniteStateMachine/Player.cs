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

    public PlayerWallSlideState WallSlideState { get; private set; }   
    
    public PlayerWallGrabState  WallGrabState { get; private set; }

    public PlayerWallClimbState WallClimbState { get; private set; }

    public PlayerWallJumpState WallJumpState { get; private set; } 

    public PlayerLedgeClimbState LedgeClimbState { get; private set; }

    public PlayerDashState DashState { get; private set; }

    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set; }


    [SerializeField]
    private PlayerData PlayerData;
    #endregion
    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }

    public Transform DashDirectionIndicator { get; private set; }
    #endregion
    #region Check Transform

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private Transform wallCheck;

    [SerializeField]
    private Transform ledgeCheck;
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
        WallSlideState = new PlayerWallSlideState(this, StateMachine, PlayerData, "wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, PlayerData, "wallGrab");    
        WallClimbState = new PlayerWallClimbState(this, StateMachine, PlayerData, "wallClimb");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, PlayerData, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, PlayerData, "ledgeClimbState");
        DashState = new PlayerDashState(this, StateMachine, PlayerData, "inAir");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, PlayerData, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, PlayerData, "crouchMove");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        DashDirectionIndicator = transform.Find("DashDirectionIndicator");

        facingDirection = 1;

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

    public void SetVelocityZero()
    {
        RB.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;   
    }
    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workspace = direction * velocity;
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

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
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, PlayerData.groundCheckRadius, PlayerData.whatIsGround);
    }
    
    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput != facingDirection)
        {
            Flip();
        }
    }


    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, PlayerData.wallCheckDistance, PlayerData.whatIsGround);
    }

    public bool CheckIfTouchingLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.right * facingDirection, PlayerData.wallCheckDistance, PlayerData.whatIsGround);
    }
    public bool CheckIfTouchingWallBack()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * -facingDirection, PlayerData.wallCheckDistance, PlayerData.whatIsGround);
    }



    #endregion
    #region Other Functions
    public Vector2 DetermineCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, PlayerData.wallCheckDistance, PlayerData.whatIsGround);
        float xDist = xHit.distance;
        workspace.Set((xDist + 0.015f) * facingDirection, 0f);
        RaycastHit2D yHit = Physics2D.Raycast(ledgeCheck.position + (Vector3)(workspace), Vector2.down, ledgeCheck.position.y - wallCheck.position.y + 0.15f, PlayerData.whatIsGround);
        float yDist = yHit.distance;

        workspace.Set(wallCheck.position.x + (xDist * facingDirection), ledgeCheck.position.y - yDist);
        return workspace;
    }
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion
}
