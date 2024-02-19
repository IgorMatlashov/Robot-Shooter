using System;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunningState : PlayerMovingState
{
    public PlayerRunningState(PlayerMovementStateMachine playerStateHolder) : base(playerStateHolder)
    {
    }

    #region IState Methods
    public override void EnterState()
    {
        stateMachine.PlayerStateReusableData.MovementSpeedModifier = groundedData.RunData.SpeedModifier;

        base.EnterState();
        
    }

    public override void UpdateState()
    {
        base.UpdateState();

        StopMovement();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    #endregion


}
