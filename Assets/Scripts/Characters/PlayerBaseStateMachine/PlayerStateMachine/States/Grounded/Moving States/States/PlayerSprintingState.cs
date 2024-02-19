public class PlayerSprintingState : PlayerMovingState
{
    public PlayerSprintingState(PlayerMovementStateMachine playerStateHolder) : base(playerStateHolder)
    {
    }

    #region IState Methods
    public override void EnterState()
    {
        stateMachine.PlayerStateReusableData.MovementSpeedModifier = groundedData.SprintData.SpeedModifier;
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (stateMachine.PlayerStateReusableData.SprintToggle) { return; }
        StopMovement();
        stateMachine.ChangeState(stateMachine.RunState);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    #endregion
}
