using Cinemachine.Utility;
using UnityEngine;

public class PlayerMovementState : IState
{
    protected PlayerMovementStateMachine stateMachine;

    protected readonly PlayerGroundedData groundedData;
    protected readonly PlayerAirborneData airborneData;

    public PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
    {
        stateMachine = playerMovementStateMachine;

        groundedData = stateMachine.Player.PlayerSO.GroundedData;
        airborneData = stateMachine.Player.PlayerSO.AirborneData;
    }

    #region IState Methods
    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void EnterState()
    {
        Debug.Log("state : " + GetType().Name);
        AddInputActionsCallbacks();
    }

    public virtual void UpdateState()
    {
    }

    public virtual void PhysicsUpdateState()
    {
        Move();
    }

    public virtual void ExitState()
    {
        RemoveInputActionsCallbacks();
    }

    public virtual void OnTriggerEnter(Collider collider)
    {
    }

    public virtual void OnTriggerExit(Collider collider)
    {
    }

    public virtual void OnAnimationEnterEvent()
    {
    }

    public virtual  void OnAnimationExitEvent()
    {
    }

    public virtual  void OnAnimationTransitionEvent()
    {
    }
    #endregion

    #region Main Methods
    private void Move()
    {

        if (stateMachine.PlayerStateReusableData.MovementVectorInput.magnitude == 0f)
        {
            return;
        }

        Vector3 movementDirectionInput = GetMovementDirectionInput();
            
        Vector3 targetRotationMovement = Rotate(movementDirectionInput);

        Vector3 groundNormal = GetGroundNormal();
        Vector3 movementDiractionOnGround = Vector3.ProjectOnPlane(targetRotationMovement, groundNormal);

        float movementSpeed = GetPlayerMovementSpeed();

        Vector3 horizontalVelocity = GetPlayerHorizontalVelocity();

        stateMachine.Player.Rigidbody.AddForce(movementDiractionOnGround * movementSpeed - horizontalVelocity, ForceMode.VelocityChange);


        Debug.DrawLine(stateMachine.Player.Rigidbody.position, stateMachine.Player.Rigidbody.position + Vector3.forward, Color.blue); //farward 
        Debug.DrawLine(stateMachine.Player.Rigidbody.position, stateMachine.Player.Rigidbody.position + stateMachine.Player.MainCameraTransform.forward, Color.green); //camera
        Debug.DrawLine(stateMachine.Player.Rigidbody.position, stateMachine.Player.Rigidbody.position + movementDirectionInput, Color.yellow); //input
        Debug.DrawLine(stateMachine.Player.Rigidbody.position, stateMachine.Player.Rigidbody.position + movementDiractionOnGround, Color.black); //direction
    }

    protected void ResetVelocity()
    {
        stateMachine.Player.Rigidbody.velocity = Vector3.zero;
    }
    #endregion

    #region Rotation Methods
    private Vector3 Rotate(Vector3 movementDirection)
    {
        Quaternion cameraRotation = Quaternion.AngleAxis(stateMachine.Player.MainCameraTransform.rotation.eulerAngles.y, Vector3.up);


        movementDirection = cameraRotation * movementDirection;

        Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);

        rotation = Quaternion.Slerp(stateMachine.Player.Rigidbody.rotation, rotation, Time.fixedDeltaTime / groundedData.PlayerRotationData.TargetRotationReachTime);

        stateMachine.Player.Rigidbody.MoveRotation(rotation);

        return movementDirection;
    }
    #endregion

    #region Getting Methods
    protected Vector3 GetPlayerVerticalVelocity()
    {
        Vector3 verticalVelocity = stateMachine.Player.Rigidbody.velocity;
        verticalVelocity.x = 0f;
        verticalVelocity.z = 0f;
        return verticalVelocity;
    }
    protected Vector3 GetPlayerHorizontalVelocity()
    {
        Vector3 horizontalVelocity = stateMachine.Player.Rigidbody.velocity;
        horizontalVelocity.y = 0f;
        return horizontalVelocity;
    }
    protected float GetPlayerMovementSpeed()
    {
        return stateMachine.PlayerStateReusableData.MovementSpeedModifier * groundedData.BaseSpeed * stateMachine.PlayerStateReusableData.MovementOnSlopesSpeedModifier;
    }
    protected Vector3 GetMovementDirectionInput()
    {
        return new Vector3(stateMachine.PlayerStateReusableData.MovementVectorInput.x, 0, stateMachine.PlayerStateReusableData.MovementVectorInput.y);
    }
    protected Vector3 GetGroundNormal()
    {
        Vector3 groundNormal = stateMachine.PlayerStateReusableData.Hit.normal;
        return groundNormal;
    }

    protected Vector4 Get 

    #endregion



    #region Setting Methods
    protected float SetSlopeSpeedModifierOnAngle(float angle)
    {
        float slopeSpeedModifier = groundedData.SlopeSpeedAngles.Evaluate(angle);

        stateMachine.PlayerStateReusableData.MovementOnSlopesSpeedModifier = slopeSpeedModifier;

        return slopeSpeedModifier;
    }

    #endregion



    #region Input Methods

    protected virtual void AddInputActionsCallbacks()
    {

    }

    protected virtual void RemoveInputActionsCallbacks()
    {

    }



    private void ReadMovementInput()
    {
        stateMachine.PlayerStateReusableData.MovementVectorInput = stateMachine.Player.Input.PlayerActions.Move.ReadValue<Vector2>();
    }
    #endregion

    #region Movement Toggle Methods




    #endregion
}