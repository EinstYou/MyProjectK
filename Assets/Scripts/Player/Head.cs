using UnityEngine;
using UnityEngine.InputSystem;

public class Head : MonoBehaviour
{

    public InputActionAsset InputActions;
    private InputAction throwAction;

    private bool canThrow;

    private Vector3 defaultPosition;
    private Transform defaultParent;



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
        canThrow = true;
        defaultParent = transform.parent;
        defaultPosition = transform.localPosition;
    }

    private void Update()
    {
        if (canThrow && throwAction.WasPressedThisFrame()) Throw();
    }

    private void Throw()
    {
        transform.parent = null;
        canThrow = false;
    }


}
