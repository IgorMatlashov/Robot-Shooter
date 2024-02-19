using System;
using UnityEngine;

[Serializable]
public class CrouchData
{
    [field: SerializeField][field: Range(0f, 10f)] public float SpeedModifier { get; private set; } = 0.5f;
}
