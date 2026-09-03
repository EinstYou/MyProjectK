using UnityEngine;


[System.Serializable]
public class HeadNormalState : HeadBaseState
{
    public override void EnterState(HeadStateManager head)
    {
        head.BlackBoard.rigidBody.isKinematic = true;
        head.BlackBoard.collider.enabled = false;

        head.transform.SetParent(head.BlackBoard.defaultParent, true);
    }

    public override void UpdateState(HeadStateManager head)
    {

        if(head.BlackBoard.direction != null) head.transform.rotation = Quaternion.Euler(0, head.BlackBoard.direction.rotation.y, 0);

        if (head.BlackBoard.throwButton.WasPressedThisFrame())
        {
            head.transform.parent = null;
            head.SwitchState(head.ThrowingState);
        }
    }
}
