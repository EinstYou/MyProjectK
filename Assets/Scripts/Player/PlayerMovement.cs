using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;




public class PlayerMovement : MonoBehaviour
{
    
    public InputActionAsset InputActions;
    
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    
    
    [SerializeField] private float speedUpScale;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    
    public Transform directionObjectTransform;
    
    
    private float friction;
    private float maxSpeed;
    
    private Vector2 inputDirection;
    private Vector3 velocity;
    
    private Rigidbody rb;
    
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
        moveAction = InputActions.FindAction("Move");
        jumpAction = InputActions.FindAction("Jump");
        sprintAction = InputActions.FindAction("Sprint");
        
        friction = speedUpScale / 2;
        maxSpeed = walkSpeed;
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        inputDirection = moveAction.ReadValue<Vector2>();
        
        Jump();
        Sprint();
    }


    private void FixedUpdate()
    {
        Move();
    }
    

    private void Move()
    {
        velocity += inputDirection.x * directionObjectTransform.right * speedUpScale * Time.deltaTime + inputDirection.y * directionObjectTransform.forward * speedUpScale * Time.deltaTime;
        velocity.y = 0;
        if(velocity != Vector3.zero)
        {
            if (velocity.magnitude < 0.1) velocity = Vector3.zero;
            velocity -= velocity.normalized * friction * Time.deltaTime;
        }
        if (velocity.magnitude > maxSpeed) velocity = velocity.normalized * maxSpeed;
        rb.linearVelocity = velocity + rb.linearVelocity.y * Vector3.up;
    }

    private void Jump()
    {
        if (jumpAction.WasPressedThisFrame())
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }

    private void Sprint()
    {
        maxSpeed = sprintAction.IsPressed() ? runSpeed : walkSpeed;
    }

}
