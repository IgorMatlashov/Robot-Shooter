using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMediumStopState : PlayerStoppingState
{
    public PlayerMediumStopState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region
    public override void EnterState()
    {
        base.EnterState();

        stateMachine.PlayerStateReusableData.MovementDecelerationForce = groundedData.PlayerStopData.MediumDevelerationForce;
    }
    #endregion
}
