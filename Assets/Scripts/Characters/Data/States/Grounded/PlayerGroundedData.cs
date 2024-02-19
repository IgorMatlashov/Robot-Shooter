using System;
using UnityEngine;

[Serializable]
public class PlayerGroundedData
{
    [field: SerializeField] [field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f;
    [field: SerializeField] public AnimationCurve SlopeSpeedAngles { get; private set; }
    [field: SerializeField] public PlayerRotationData PlayerRotationData { get; private set; }
    [field: SerializeField] public WalkData WalkData { get; private set; }
    [field: SerializeField] public RunData RunData { get; private set; }
    [field: SerializeField] public SprintData SprintData { get; private set; }
    [field: SerializeField] public CrouchData CrouchData { get; private set; }
    [field: SerializeField] public PlayerStopData PlayerStopData { get; private set; }
}
