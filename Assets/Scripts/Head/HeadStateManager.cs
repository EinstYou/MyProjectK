using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadStateManager : MonoBehaviour
{

    
    public HeadBlackBoard BlackBoard = new HeadBlackBoard();


    private HeadBaseState currentState;
    public HeadStandState StandState = new HeadStandState();
    public HeadNormalState NormalState = new HeadNormalState();
    public HeadThrowingState ThrowingState = new HeadThrowingState();


    private void OnEnable()
    {
        BlackBoard.InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        BlackBoard.InputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        BlackBoard.throwButton = BlackBoard.InputActions.FindAction("Throw");
    }

    private void Start()
    {
        BlackBoard.rigidBody = GetComponent<Rigidbody>();
        BlackBoard.animator = GetComponent<Animator>();
        BlackBoard.collider = GetComponent<SphereCollider>();

        BlackBoard.defaultParent = transform.parent;
        BlackBoard.defaultPosition = transform.localPosition;

        if (BlackBoard.direction == null) BlackBoard.direction = transform;

        SwitchState(NormalState);
    }

   
    void Update()
    {
        currentState.UpdateState(this);
    }


    public void SwitchState(HeadBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
