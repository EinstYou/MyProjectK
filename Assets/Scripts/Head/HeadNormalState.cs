using UnityEngine;


[System.Serializable]
public class HeadNormalState : HeadBaseState
{
    public override void EnterState(HeadStateManager head)
    {
        head.BlackBoard.rigidBody.isKinematic = true;
        head.BlackBoard.collider.enabled = false;

        head.transform.parent = head.BlackBoard.defaultParent;
        head.transform.localPosition = head.BlackBoard.defaultPosition;
    }

    public override void UpdateState(HeadStateManager head)
    {

        if (head.BlackBoard.direction != null) head.transform.rotation = head.BlackBoard.direction.rotation;

        if (head.BlackBoard.throwButton.WasPressedThisFrame())
        {
            head.SwitchState(head.ThrowingState);
        }
    }
}
