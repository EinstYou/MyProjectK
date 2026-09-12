using System.Collections;
using UnityEngine;


[System.Serializable]
public class HeadStandState : HeadBaseState
{



    private float rotationY = 0f;
    public override void EnterState(HeadStateManager head)
    {
        head.BlackBoard.rigidBody.isKinematic = true;
        head.StartCoroutine(HeadDuration(head.BlackBoard.headDuration, head));
    }

    public override void UpdateState(HeadStateManager head)
    {
        rotationY += Time.deltaTime * head.BlackBoard.rotationSpeed;
        if (rotationY >= 360) rotationY = rotationY - 360;
        head.transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }


    IEnumerator HeadDuration(float time, HeadStateManager head)
    {
        yield return new WaitForSeconds(time);
        head.BlackBoard.animator.SetBool("IsThrowed", true);
        head.enabled = false;

        yield return new WaitForSeconds(time);
        head.BlackBoard.animator.SetBool("IsThrowed", false);
        head.enabled = true;
        head.SwitchState(head.NormalState);
    }

}
