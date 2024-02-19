using System;
using UnityEngine;

[Serializable]
public class PlayerDefaultColliderData
{
    [field: SerializeField] public float Height { get; private set; } = 1.9f;
    [field: SerializeField] public float CenterY { get; private set; } = 0f;
    [field: SerializeField] public float Radius { get; private set; } = 0.25f;
}
