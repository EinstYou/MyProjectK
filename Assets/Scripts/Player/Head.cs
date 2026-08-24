using UnityEngine;
using UnityEngine.InputSystem;

public class Head : MonoBehaviour
{

    public InputActionAsset InputActions;
    private InputAction throwAction;

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
        throwAction = InputActions.FindAction("Throw");
    }

    private void Start()
    {
        isThrowing = false;
    }

    private void Throw()
    {

    }


}
