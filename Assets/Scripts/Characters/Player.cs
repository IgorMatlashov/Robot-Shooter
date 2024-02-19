using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent (typeof(PlayerResizableCapsuleCollider))]
public class Player : MonoBehaviour
{
    [field: Header("References PLayer SO")]
    [field: SerializeField] public PlayerSO PlayerSO { get; private set; }

    [field: Header("Collisions Layer Ground")]
    [field: SerializeField] public PlayerLayerData LayerData { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public PlayerInput Input { get; private set; }

    public Transform MainCameraTransform { get; private set; }

    public PlayerResizableCapsuleCollider PlayerResizableCapsuleCollider { get; private set; }

    private PlayerMovementStateMachine movementStateMachine;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();

        Input = GetComponent<PlayerInput>();

        MainCameraTransform = Camera.main.transform;

        PlayerResizableCapsuleCollider = GetComponent<PlayerResizableCapsuleCollider>();

        movementStateMachine = new PlayerMovementStateMachine(this);
    }

    private void Start()
    {
        movementStateMachine.ChangeState(movementStateMachine.IdleState);
    }

    private void Update()
    {
        movementStateMachine.HandleInput();

        movementStateMachine.UpdateState();
    }

    private void FixedUpdate()
    {
        movementStateMachine.PhysicsUpdateState();
    }

    private void OnTriggerEnter(Collider collider)
    {
        movementStateMachine.OnTriggerEnter(collider);
    }

    private void OnTriggerExit(Collider collider)
    {
        movementStateMachine.OnTriggerExit(collider);
    }

    public void OnMovementStateAnimationEnterEvent()
    {
        movementStateMachine.OnAnimationEnterEvent();
    }

    public void OnMovementStateAnimationExitEvent()
    {
        movementStateMachine.OnAnimationExitEvent();
    }

    public void OnMovementStateAnimationTransitionEvent()
    {
        movementStateMachine.OnAnimationTransitionEvent();
    }
}
