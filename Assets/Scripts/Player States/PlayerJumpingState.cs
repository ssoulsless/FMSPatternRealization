﻿using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    public override void EnterState(PlayerController_FSM player)
    {
        player.SetExpression(player.jumpingSprite);
    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {
        player.TransitionToState(player.playerIdleState);
    }

    public override void Update(PlayerController_FSM player)
    {
        if (Input.GetButtonDown("Duck"))
        {
            player.TransitionToState(new PlayerSpinningState());
        }
    }
}
