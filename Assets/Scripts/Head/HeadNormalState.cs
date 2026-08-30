using UnityEngine;


[System.Serializable]
public class HeadNormalState : HeadBaseState
{
    public override void EnterState(HeadStateManager head)
    {
        
    }

    public override void UpdateState(HeadStateManager head)
    {
        if (head.BlackBoard.throwButton.WasPressedThisFrame())
        {
            head.transform.parent = null;
            head.SwitchState(head.ThrowingState);
        }
    }
}
