using System;
using UnityEngine;

[Serializable]
public class PlayerStopData
{
    [field: SerializeField] [field: Range(0f, 15f)] public float LightDevelerationForce { get; private set; } = 5f;
    [field: SerializeField] [field: Range(0f, 15f)] public float MediumDevelerationForce { get; private set; } = 6.5f;
    [field: SerializeField] [field: Range(0f, 15f)] public float HardDevelerationForce { get; private set; } = 5f;
}
