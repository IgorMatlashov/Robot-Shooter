public class PlayerWalkingState : PlayerMovingState
{
    public PlayerWalkingState(PlayerMovementStateMachine playerStateHolder) : base(playerStateHolder)
    {
    }

    #region Istate Methods
    public override void EnterState()
    {
        stateMachine.PlayerStateReusableData.MovementSpeedModifier = groundedData.WalkData.SpeedModifier;
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (stateMachine.PlayerStateReusableData.WalkToggle) { return; }
        StopMovement();
        stateMachine.ChangeState(stateMachine.RunState);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    #endregion

}
