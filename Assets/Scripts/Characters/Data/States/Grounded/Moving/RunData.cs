using System;
using UnityEngine;

[Serializable]
public class RunData
{
    [field: SerializeField] [field: Range(1f, 5f)] public float SpeedModifier { get; private set; } = 1f;
}
