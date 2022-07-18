using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpsLeft : PlayerAbilityState
{
    public int amountOfJumpsLeft;

    //playerData.amountOfJumps
    public Text ValueText;

    public JumpsLeft(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    private void Start()
    {
        amountOfJumpsLeft = playerData.amountOfJumps;

        Debug.Log(amountOfJumpsLeft);
    }

    private void Update()
    {
        ValueText.text = "Jumps: " + amountOfJumpsLeft.ToString();

        Debug.Log(amountOfJumpsLeft);

    }
}
