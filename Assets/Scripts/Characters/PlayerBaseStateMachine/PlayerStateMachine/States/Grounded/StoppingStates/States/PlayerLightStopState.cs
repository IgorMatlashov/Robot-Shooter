using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightStopState : PlayerStoppingState
{
    public PlayerLightStopState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region IState Methods
    public override void EnterState()
    {
        base.EnterState();

        stateMachine.PlayerStateReusableData.MovementDecelerationForce = groundedData.PlayerStopData.LightDevelerationForce;
    }
    #endregion
}
