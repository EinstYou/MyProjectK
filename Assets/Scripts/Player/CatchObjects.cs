using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class CatchObjects : MonoBehaviour
{
    public InputActionAsset InputActions;
    private InputAction catchAction;
    
    [SerializeField] private GameObject playerHead;
    [SerializeField] private float coolDown;
    [SerializeField] private float throwSpeed;
    [SerializeField] private float distance;

    private Vector3 defaultHeadPosition;
    private Transform defaultHeadParent;

    private Vector3 maxPosition;
    
    
    private PlayerMovement playerMovement;


    private bool isThrowing;
    
    


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
        catchAction = InputActions.FindAction("Catch");
    }

    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        isThrowing = false;
        defaultHeadPosition = playerHead.transform.localPosition;
        defaultHeadParent = playerHead.transform.parent;
    }

    

    private void Update()
    {
        
        if (catchAction.WasPressedThisFrame() && !isThrowing)
        {
            Debug.Log(playerHead.transform.localPosition);
            ThrowHead();
        }

        MoveHead();
    }


    
    
    private void ResetHead()
    {
        playerHead.transform.parent = defaultHeadParent;
        playerHead.transform.localPosition = defaultHeadPosition;
        isThrowing = false;
    }

    private void ThrowHead()
    {
        playerHead.transform.parent = null;
        maxPosition = transform.position + playerMovement.directionObjectTransform.forward * distance;
        isThrowing = true;
        StartCoroutine(HeadComeBack());
    }


    private void MoveHead()
    {
       if(isThrowing) playerHead.transform.position = Vector3.Lerp(playerHead.transform.position, maxPosition, Time.deltaTime * throwSpeed);
  
    }

    IEnumerator HeadComeBack()
    {
        yield return new WaitForSeconds(coolDown);
        ResetHead();
    }

}
