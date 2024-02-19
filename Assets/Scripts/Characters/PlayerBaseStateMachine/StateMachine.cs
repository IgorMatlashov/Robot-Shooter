using UnityEngine;

public abstract class StateMachine
{
    protected IState currentState;

    public void ChangeState(IState newState)
    {
        currentState?.ExitState();

        currentState = newState;

        currentState.EnterState();
    }

    public void HandleInput()
    {
        currentState?.HandleInput();
    }

    public void UpdateState()
    {
        currentState?.UpdateState();
    }

    public void PhysicsUpdateState()
    {
        currentState?.PhysicsUpdateState();
    }
    public void OnTriggerEnter(Collider collider)
    {
        currentState?.OnTriggerEnter(collider);
    }

    public void OnTriggerExit(Collider collider)
    {
        currentState?.OnTriggerExit(collider);
    }

    public void OnAnimationEnterEvent()
    {
        currentState?.OnAnimationEnterEvent();
    }

    public void OnAnimationExitEvent()
    {
        currentState?.OnAnimationExitEvent();
    }

    public void OnAnimationTransitionEvent()
    {
        currentState?.OnAnimationTransitionEvent();
    }
}