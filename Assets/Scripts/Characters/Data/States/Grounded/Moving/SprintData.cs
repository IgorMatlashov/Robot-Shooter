using System;
using UnityEngine;

[Serializable]
public class SprintData
{
    [field: SerializeField][field: Range(1f, 10f)] public float SpeedModifier { get; private set; } = 3f;
}
