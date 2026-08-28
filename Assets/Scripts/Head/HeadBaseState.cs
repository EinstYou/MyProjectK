using UnityEngine;

public abstract class HeadBaseState
{
    public abstract void EnterState(HeadStateManager head);

    public abstract void UpdateState(HeadStateManager head);

    public abstract void OnThrowPressed(HeadStateManager head);
}
