using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpsLeft : PlayerAbilityState
{
    private int amountOfJump;

    //playerData.amountOfJumps
    public Text ValueText;

    public JumpsLeft(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
       // amountOfJump = PlayerJumpState.amountOfJumpsLeft;
    }

    private void Start()
    {
        //amountOfJump = PlayerJumpState.amountOfJumpsLeft;

        Debug.Log(amountOfJump);
    }

    private void Update()
    {
        ValueText.text = "Jumps: " + amountOfJump.ToString();

        Debug.Log(amountOfJump);

    }
}
