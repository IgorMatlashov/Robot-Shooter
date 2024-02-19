public class PlayerCrouchingState : PlayerMovingState
{
    public PlayerCrouchingState(PlayerMovementStateMachine playerStateHolder) : base(playerStateHolder)
    {
    }

    #region IState Methods
    public override void EnterState()
    {
        stateMachine.PlayerStateReusableData.MovementSpeedModifier = groundedData.CrouchData.SpeedModifier;
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (stateMachine.PlayerStateReusableData.CrouchToggle) { return; }
        StopMovement();
        stateMachine.ChangeState(stateMachine.RunState);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    #endregion
}
