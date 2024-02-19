using System;
using UnityEngine;

[Serializable]
public class PlayerRotationData
{
    [field: SerializeField] [field: Range(0f, 2f)] public float TargetRotationReachTime { get; private set; } = 0.14f;
}
