using UnityEngine;


[System.Serializable]
public class HeadThrowingState : HeadBaseState
{
    public override void EnterState(HeadStateManager head)
    {
        head.transform.SetParent(null, false);
        head.BlackBoard.rigidBody.isKinematic = false;
        head.BlackBoard.collider.enabled = true;
        head.BlackBoard.rigidBody.AddForce(head.BlackBoard.direction.forward * head.BlackBoard.throwForce, ForceMode.Impulse);
    }

    public override void UpdateState(HeadStateManager head)
    {

        /*
        if(head.BlackBoard.rigidBody.linearVelocity.magnitude < 0.1f)
        {
            head.SwitchState(head.StandState);
        }
        */
    }

   
}
