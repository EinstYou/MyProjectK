using System.Collections;
using UnityEngine;


[System.Serializable]
public class HeadStandState : HeadBaseState
{
    public override void EnterState(HeadStateManager head)
    {
        head.BlackBoard.rigidBody.isKinematic = true;
        head.StartCoroutine(HeadDuration(head.BlackBoard.headDuration, head));
    }

    public override void UpdateState(HeadStateManager head)
    {
        
    }


    IEnumerator HeadDuration(float time, HeadStateManager head)
    {
        yield return new WaitForSeconds(time);
        head.BlackBoard.animator.Play("ResetIN");
    }

}
