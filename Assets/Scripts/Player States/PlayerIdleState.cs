using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerController_FSM player)
    {
        player.SetExpression(player.idleSprite);
    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {

    }

    public override void Update(PlayerController_FSM player)
    {
        if (Input.GetButtonDown("Jump"))
        {
            player.Rbody.AddForce(Vector3.up * player.jumpForce);
            player.TransitionToState(player.playerJumpingState);
        }
        else if (Input.GetButtonDown("Duck"))
        {
            player.head.position = new Vector3(player.head.position.x, 0.5f, player.head.position.z);
            player.TransitionToState(player.playerDuckingState);
        }
        else if (Input.GetButtonDown("SwapWeapon"))
        {
            bool usingWeapon = player.weapon01.gameObject.activeInHierarchy;

            player.weapon01.gameObject.SetActive(!usingWeapon);
            player.weapon02.gameObject.SetActive(usingWeapon);
        }
    }
}
