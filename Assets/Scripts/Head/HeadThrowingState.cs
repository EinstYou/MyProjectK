using UnityEngine;


[System.Serializable]
public class HeadThrowingState : HeadBaseState
{


    private float currentVelocity = 0;
    private float nextVelocity = 0;
    public override void EnterState(HeadStateManager head)
    {
        head.transform.parent = null;
        head.BlackBoard.rigidBody.isKinematic = false;
        head.BlackBoard.collider.enabled = true;
        head.BlackBoard.rigidBody.AddForce(head.BlackBoard.direction.forward * head.BlackBoard.throwForce, ForceMode.Impulse);
    }

    public override void UpdateState(HeadStateManager head)
    {
        nextVelocity = head.BlackBoard.rigidBody.linearVelocity.magnitude;
        if (nextVelocity < currentVelocity && nextVelocity < 0.1f)
        {
            head.SwitchState(head.StandState);
        }
        currentVelocity = nextVelocity;
    }

   
}
