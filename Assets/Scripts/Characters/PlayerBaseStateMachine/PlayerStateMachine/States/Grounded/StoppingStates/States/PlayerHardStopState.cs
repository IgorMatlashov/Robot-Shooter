using UnityEngine.InputSystem;
public class PlayerHardStopState : PlayerStoppingState
{
    public PlayerHardStopState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region
    public override void EnterState()
    {
        base.EnterState();

        stateMachine.PlayerStateReusableData.MovementDecelerationForce = groundedData.PlayerStopData.HardDevelerationForce;
    }
    #endregion
    #region Reusable Methods

    #endregion
}
