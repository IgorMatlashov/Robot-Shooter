using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void EnterState();
    public void HandleInput();
    public void UpdateState();
    public void PhysicsUpdateState();
    public void ExitState();
    public void OnTriggerEnter(Collider collider);
    public void OnTriggerExit(Collider collider);
    public void OnAnimationEnterEvent();
    public void OnAnimationExitEvent();
    public void OnAnimationTransitionEvent();
}
