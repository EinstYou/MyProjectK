
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    
    public InputActionAsset InputActions;
    
    private InputAction lookAction;
    
    
    [SerializeField] private float sensX = 400f;
    [SerializeField] private float sensY = 400f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask objectLayer;
    [SerializeField] private float maxCameraDistance = 10f;
    [SerializeField] private float minCameraDistance = 3;
    [SerializeField] private float cameraSpeed = 20f;
    [SerializeField] private float padding = 0.1f;
    
    private float currentCameraDistance;
    
    private PlayerMovement playerMovement;
    
    
    private float cameraX;
    private float cameraY;

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
        lookAction = InputActions.FindAction("Look");
        Cursor.lockState = CursorLockMode.Locked;
        currentCameraDistance = maxCameraDistance;
    }


    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    

    private void Update()
    {
        cameraX -= lookAction.ReadValue<Vector2>().x * sensX * Time.deltaTime;
        cameraY += lookAction.ReadValue<Vector2>().y * sensY * Time.deltaTime;
        
        cameraX = Mathf.Clamp(cameraX, -90, 90);
    }


    private void LateUpdate()
    {
        CameraMovement();
    }


    private void CameraMovement()
    {
        transform.rotation = Quaternion.Euler(cameraX, cameraY, 0);
        if(playerMovement) playerMovement.directionObjectTransform.rotation = Quaternion.Euler(0, cameraY, 0);
        
        
        Vector3 direction = -transform.forward;
        if (Physics.Raycast(transform.position, direction.normalized, out RaycastHit hit, maxCameraDistance,objectLayer))
        {
            currentCameraDistance = hit.distance - padding;
        }
        else
        {
            currentCameraDistance = Mathf.Lerp(currentCameraDistance, maxCameraDistance, Time.deltaTime * cameraSpeed);
        }
        currentCameraDistance = Mathf.Clamp(currentCameraDistance, minCameraDistance, maxCameraDistance);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, transform.position + direction * currentCameraDistance, Time.deltaTime * cameraSpeed);
    }
    
}
