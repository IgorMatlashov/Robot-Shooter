using UnityEngine;

public class PlayerIdlingState : PlayerGroundedState
{
    public PlayerIdlingState(PlayerMovementStateMachine playerStateHolder) : base(playerStateHolder)
    {
    }

    #region IState Methods
    public override void EnterState()
    {
        stateMachine.PlayerStateReusableData.MovementSpeedModifier = 0f;
        ResetVelocity();
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (stateMachine.PlayerStateReusableData.MovementVectorInput == Vector2.zero) { return; }
        OnMove();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    #endregion
}
