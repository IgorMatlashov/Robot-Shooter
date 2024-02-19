public class PlayerMovementStateMachine : StateMachine
{
    public Player Player { get; }
    public PlayerStateReusableData PlayerStateReusableData { get; }

    public PlayerIdlingState IdleState { get; }

    public PlayerWalkingState WalkState { get; }
    public PlayerRunningState RunState { get; }
    public PlayerSprintingState SprintState { get; }
    public PlayerCrouchingState CrouchState { get; }

    public PlayerMovementStateMachine(Player player)
    {
        Player = player;

        PlayerStateReusableData = new PlayerStateReusableData();

        IdleState = new PlayerIdlingState(this);

        WalkState = new PlayerWalkingState(this);
        RunState = new PlayerRunningState(this);
        SprintState = new PlayerSprintingState(this);
        CrouchState = new PlayerCrouchingState(this);

    }


}
