using UnityEngine;

public class PlayerStateReusableData
{
    public Vector2 MovementVectorInput { get; set; }

    public float MovementSpeedModifier { get; set; } = 1f;
    public float MovementOnSlopesSpeedModifier { get; set; } = 1f;
    public float MovementDecelerationForce { get; set; } = 1f;

    public RaycastHit Hit;

    public bool WalkToggle {  get; set; }
    public bool SprintToggle {  get; set; }
    public bool CrouchToggle {  get; set; }



    private Vector3 currentCameraRotation;
    private Vector3 timeToReachTargetRotation;
    private Vector3 dampedTargetRotationCurrentVelocity;
    private Vector3 dampedTargetRotationPassedTime;

    public ref Vector3 CurrentCameraRotation
    {
        get
        {
            return ref currentCameraRotation;
        }
    }

    public ref Vector3 TimeToReachTargetRotation
    {
        get
        {
            return ref timeToReachTargetRotation;
        }
    }
    public ref Vector3 DampedTargetRotationCurrentVelocity
    {
        get
        {
            return ref dampedTargetRotationCurrentVelocity;
        }
    }
    public ref Vector3 DampedTargetRotationPassedTime
    {
        get
        {
            return ref dampedTargetRotationPassedTime;
        }
    }
}
