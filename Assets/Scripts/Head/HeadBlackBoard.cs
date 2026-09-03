using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class HeadBlackBoard
{
    public float throwForce;
    public InputActionAsset InputActions;
    public Transform direction;

    [HideInInspector] public InputAction throwButton;
    [HideInInspector] public Rigidbody rigidBody;
    [HideInInspector] public SphereCollider collider;
    [HideInInspector] public Animator animator;
    [HideInInspector] public Transform defaultParent;
    [HideInInspector] public Vector3 defaultPosition;


}