using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{

    [SerializeField] private GameObject damageParticles;
    public bool CanDash { get; private set; }
    private bool DashInputStop;

    private float lastDashTime;
     
    private bool isHolding;

    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;

    private Vector2 lastAfterimagePosition;

    private AudioClip jumpSound;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        
        CanDash = false;
        player.InputHandler.UseDashInput();
        isHolding = true;
        dashDirection = Vector2.right * Movement.FacingDirection;
        Time.timeScale = playerData.holdTimeScale;
        startTime = Time.unscaledTime;

        player.DashDirectionIndicator.gameObject.SetActive(true); // turn ON indicator 

    }

    public override void Exit()
    {
        base.Exit();
        if(Movement?.CurrentVelocity.y > 0)
        {
            Movement?.SetVelocityY(Movement.CurrentVelocity.y * playerData.dashEndYMultiplier);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            player.Anim.SetFloat("yVelocity", Movement.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(Movement.CurrentVelocity.x));

            if (isHolding)
            {
                //SoundMenager.instance.PlaySound(playerData.dashSound);

                dashDirectionInput = player.InputHandler.DashDirectionInput;
                //determine directoin, set graphic
                DashInputStop = player.InputHandler.DashInputStop;

                if (dashDirectionInput != Vector2.zero)
                {
                    dashDirection = dashDirectionInput;
                    dashDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
                player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 30f);

                if (DashInputStop || Time.unscaledTime >= startTime + playerData.maxHoldTime)
                {
                    SoundMenager.instance.PlaySound(playerData.dashSound);

                    isHolding = false;
                    Time.timeScale = 1f;
                    startTime = Time.time;
                    Movement?.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
                    player.RB.drag = playerData.drag;
                    Movement?.SetVelocity(playerData.dashVelocity, dashDirection);
                    player.DashDirectionIndicator.gameObject.SetActive(false);
                    PlaceAfterImage();
                }
            }
            else
            {
                Movement?.SetVelocity(playerData.dashVelocity, dashDirection);
                CheckIfShouldPlaceAfterImage();

                if (Time.time >= startTime + playerData.dashTime)
                {
                    player.RB.drag = 0f;
                    isAbilityDone = true;
                    lastDashTime = Time.time;
                }
            }
        }
    }

    private void CheckIfShouldPlaceAfterImage() // compare current position with last AIP
    {
        if(Vector2.Distance(player.transform.position, lastAfterimagePosition) >= playerData.distanceBetweenAfterImages)
        {
            PlaceAfterImage();
        }
    }
    private void PlaceAfterImage()
    {
        PlayerAfterImagePool.Instance.GetFromPool();
        lastAfterimagePosition = player.transform.position;
    }


    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    public void ResetCanDash() => CanDash = true;

 
}
