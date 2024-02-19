using UnityEngine;

public class PlayerResizableCapsuleCollider : MonoBehaviour
{
    public CapsuleColliderData CapsuleColliderData { get; private set; }
    [field: SerializeField] public PlayerDefaultColliderData PlayerDefaultColliderData { get; private set; }
    [field: SerializeField] public SlopeData SlopeData { get; private set; }
    private void Awake()
    {
        Resize();
    }

    private void OnValidate()
    {
        Resize();
    }

    public void Resize()
    {
        Initialize(gameObject);

        CalculateCapsuleColliderDimensions();
    }

    public void Initialize(GameObject gameObject)
    {
        if (CapsuleColliderData != null)
        {
            return;
        }

        CapsuleColliderData = new CapsuleColliderData();

        CapsuleColliderData.Initialize(gameObject);
    }

    public void CalculateCapsuleColliderDimensions()
    {
        SetCapsuleColliderRadius(PlayerDefaultColliderData.Radius);

        SetCapsuleColliderHeight(PlayerDefaultColliderData.Height * (1f - SlopeData.StepHeightPrecentage));

        RecalculateCapsuleColliderCenter();

        RecalculateColliderRadius();

        CapsuleColliderData.UpdateColliderData();
    }

    public void SetCapsuleColliderRadius(float radius)
    {
        CapsuleColliderData.Collider.radius = radius;
    }

    public void SetCapsuleColliderHeight(float height)
    {
        CapsuleColliderData.Collider.height = height;
    }

    public void RecalculateCapsuleColliderCenter()
    {
        float colliderHeightDifference = PlayerDefaultColliderData.Height - CapsuleColliderData.Collider.height;

        Vector3 newColliderCenter = new Vector3(0f, PlayerDefaultColliderData.CenterY + (colliderHeightDifference / 2f), 0f);

        CapsuleColliderData.Collider.center = newColliderCenter;
    }

    public void RecalculateColliderRadius()
    {
        float halfColliderHeight = CapsuleColliderData.Collider.height / 2f;

        if (halfColliderHeight >= CapsuleColliderData.Collider.radius)
        {
            return;
        }

        SetCapsuleColliderRadius(halfColliderHeight);
    }
}
