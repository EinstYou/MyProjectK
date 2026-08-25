using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Head : MonoBehaviour
{

    public InputActionAsset InputActions;
    private InputAction throwAction;

    private bool isThrowing;

    private Vector3 defaultPosition;
    private Transform defaultParent;

    private PlayerMovement playerMovement;

    private SphereCollider collider;



    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        throwAction = InputActions.FindAction("Throw");
    }

    private void Start()
    {
        isThrowing = false;
        defaultParent = transform.parent;
        defaultPosition = transform.localPosition;
        playerMovement = GetComponentInParent<PlayerMovement>();
        collider = GetComponentInParent<SphereCollider>();
    }

    private void Update()
    {
        if (!isThrowing && throwAction.WasPressedThisFrame()) Throw();
        MoveAndRotate();
    }

    private void Throw()
    {
        transform.parent = null;
        isThrowing = true;
    }

    private void MoveAndRotate()
    {
        transform.rotation = playerMovement.directionObjectTransform.rotation;
        if (collider) collider.enabled = isThrowing;
    }


}
