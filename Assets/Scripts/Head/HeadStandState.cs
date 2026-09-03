using UnityEngine;


[System.Serializable]
public class HeadStandState : HeadBaseState
{
    public override void EnterState(HeadStateManager head)
    {
        head.BlackBoard.rigidBody.isKinematic = true;
    }

    public override void UpdateState(HeadStateManager head)
    {

    }
}
