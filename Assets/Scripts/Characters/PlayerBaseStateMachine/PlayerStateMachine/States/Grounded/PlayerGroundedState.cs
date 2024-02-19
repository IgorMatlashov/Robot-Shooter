using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerMovementState
{
    public PlayerGroundedState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region IState Methods
    public override void EnterState()
    {
        base.EnterState();
    }
    public override void UpdateState()
    {
        base.UpdateState();
    }
    public override void PhysicsUpdateState()
    {
        base.PhysicsUpdateState();

        FloatCollider();
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    #endregion

    #region Main Movement Methods
    private void FloatCollider()
    {
        Vector3 capsuleColliderCenterInWorldSpace = stateMachine.Player.PlayerResizableCapsuleCollider.CapsuleColliderData.Collider.bounds.center;
        Ray downwardsRayFromCapsuleCenter = new Ray(capsuleColliderCenterInWorldSpace, Vector3.down);

        if (Physics.Raycast(downwardsRayFromCapsuleCenter, out stateMachine.PlayerStateReusableData.Hit, stateMachine.Player.PlayerResizableCapsuleCollider.SlopeData.FloatRayDistance, stateMachine.Player.LayerData.GroundLayer, QueryTriggerInteraction.Ignore))
        {
            float desiredDistance = stateMachine.Player.PlayerResizableCapsuleCollider.PlayerDefaultColliderData.Height / 2 + stateMachine.Player.PlayerResizableCapsuleCollider.CapsuleColliderData.Collider.center.y;

            float differenceDesiredAndDistance = desiredDistance - stateMachine.PlayerStateReusableData.Hit.distance;

            float groundAngle = Vector3.Angle(stateMachine.PlayerStateReusableData.Hit.normal, Vector3.up);


            if (differenceDesiredAndDistance == 0)
            {
                return;
            }

            float amountToLift = differenceDesiredAndDistance * stateMachine.Player.PlayerResizableCapsuleCollider.SlopeData.StepReachForce - GetPlayerVerticalVelocity().y;

            Vector3 amountToForce = new Vector3(0f, amountToLift, 0f);
            stateMachine.Player.Rigidbody.AddForce(amountToForce, ForceMode.VelocityChange);
        }
    }

    protected virtual void OnMove()
    {
        if (stateMachine.PlayerStateReusableData.SprintToggle)
        {
            stateMachine.ChangeState(stateMachine.SprintState);
        }
        if (stateMachine.PlayerStateReusableData.CrouchToggle)
        {
            stateMachine.ChangeState(stateMachine.CrouchState);
        }
        if (stateMachine.PlayerStateReusableData.WalkToggle)
        {
            stateMachine.ChangeState(stateMachine.WalkState);
        }
        stateMachine.ChangeState(stateMachine.RunState);
    }

    protected virtual void StopMovement()
    {
        if (stateMachine.PlayerStateReusableData.MovementVectorInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }
    }
    #endregion

    #region Input Methods
    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        stateMachine.Player.Input.PlayerActions.Walk.started += OnWalkStarted;
        stateMachine.Player.Input.PlayerActions.Walk.canceled += OnWalkCanceled;

        stateMachine.Player.Input.PlayerActions.Sprint.started += OnSprintStarted;
        stateMachine.Player.Input.PlayerActions.Sprint.canceled += OnSprintCanceled;

        stateMachine.Player.Input.PlayerActions.Crouch.started += OnCrouchStarted;
        stateMachine.Player.Input.PlayerActions.Crouch.canceled += OnCrouchCanceled;
    }


    protected override void RemoveInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        stateMachine.Player.Input.PlayerActions.Walk.started -= OnWalkStarted;
        stateMachine.Player.Input.PlayerActions.Walk.canceled -= OnWalkCanceled;

        stateMachine.Player.Input.PlayerActions.Sprint.started -= OnSprintStarted;
        stateMachine.Player.Input.PlayerActions.Sprint.canceled -= OnSprintCanceled;

        stateMachine.Player.Input.PlayerActions.Crouch.started -= OnCrouchStarted;
        stateMachine.Player.Input.PlayerActions.Crouch.canceled -= OnCrouchCanceled;
    }

    #endregion

    #region Action Methods
    protected virtual void OnWalkStarted(InputAction.CallbackContext context)
    {
        stateMachine.PlayerStateReusableData.WalkToggle = true;
        stateMachine.ChangeState(stateMachine.WalkState);
    }

    protected virtual void OnWalkCanceled(InputAction.CallbackContext context)
    {
        stateMachine.PlayerStateReusableData.WalkToggle = false;
    }

    protected virtual void OnSprintStarted (InputAction.CallbackContext context)
    {
        stateMachine.PlayerStateReusableData.SprintToggle = true;
        stateMachine.ChangeState(stateMachine.SprintState);
    }

    protected virtual void OnSprintCanceled(InputAction.CallbackContext context)
    {
        stateMachine.PlayerStateReusableData.SprintToggle = false;
    }

    protected virtual void OnCrouchStarted(InputAction.CallbackContext context)
    {
        stateMachine.PlayerStateReusableData.CrouchToggle = true;
        stateMachine.ChangeState(stateMachine.CrouchState);
    }

    protected virtual void OnCrouchCanceled(InputAction.CallbackContext context)
    {
        stateMachine.PlayerStateReusableData.CrouchToggle = false;
    }
    #endregion

}
