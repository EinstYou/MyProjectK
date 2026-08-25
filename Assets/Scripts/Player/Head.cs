using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Head : MonoBehaviour
{
    [SerializeField] private float throwSpeed;
    [SerializeField] private float coolDown;
    public InputActionAsset InputActions;

    private InputAction throwAction;
    private bool isThrowing;
    private bool isCoolingDown; 

    private Vector3 defaultPosition;
    private Transform defaultParent;

    private PlayerMovement playerMovement;
    private SphereCollider collider;
    private Rigidbody rb;
    private Animator animator;

    private void OnEnable()
    {
        if (InputActions != null)
            InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        if (InputActions != null)
            InputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        if (InputActions != null)
            throwAction = InputActions.FindAction("Throw");

        collider = GetComponentInParent<SphereCollider>();
        rb = GetComponentInParent<Rigidbody>();
        animator = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        isThrowing = false;
        isCoolingDown = false;

        playerMovement = GetComponentInParent<PlayerMovement>();

        defaultParent = transform.parent;
        defaultPosition = transform.localPosition;
    }

    private void Update()
    {
        if (!isThrowing && !isCoolingDown && throwAction != null && throwAction.WasPressedThisFrame())
        {
            Throw();
        }
    }

    private void FixedUpdate()
    {
        if (isThrowing)
        {
            rb.AddForce(playerMovement.directionObjectTransform.forward * throwSpeed, ForceMode.Impulse);
            isThrowing = false;
        }
        
        else if (transform.parent == null && !isCoolingDown && rb.linearVelocity.magnitude < 0.1f)
        {
            StartCoroutine(CoolDown());
            if(animator) animator.Play("ResetIN");
        }
    }

    private void LateUpdate()
    {
        Rotate();
    }

    private void Throw()
    {
        if (animator) animator.Play("Throw");

        transform.parent = null;
        if (rb) rb.isKinematic = false;
        if (collider) collider.enabled = true;

        isThrowing = true;
    }

    private void Rotate()
    {
        if (transform.parent == defaultParent && playerMovement != null && playerMovement.directionObjectTransform != null)
        {
            transform.rotation = playerMovement.directionObjectTransform.rotation;
        }
    }

    private void Reset()
    {
        if (rb)
        {
            rb.isKinematic = true;
        }

        if (collider) collider.enabled = false;

        transform.parent = defaultParent;
        transform.localPosition = defaultPosition;


        isThrowing = false;
        isCoolingDown = false;
    }

    private IEnumerator CoolDown()
    {
        isCoolingDown = true;
        if (rb) rb.isKinematic = true;

        yield return new WaitForSeconds(coolDown);
        Reset();
    }
}