using UnityEngine;

public class PlayerDuckingState : PlayerBaseState
{
    public override void EnterState(PlayerController_FSM player)
    {
        player.SetExpression(player.duckingSprite);
    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {

    }

    public override void Update(PlayerController_FSM player)
    {
        if (Input.GetButtonUp("Duck"))
        {
            player.head.position = new Vector3(player.head.position.x, 0.8f, player.head.position.z);
            player.TransitionToState(player.playerIdleState);
        }
    }
}
