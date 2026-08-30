using UnityEngine;
[System.Serializable]
public abstract class HeadBaseState
{
    public abstract void EnterState(HeadStateManager head);

    public abstract void UpdateState(HeadStateManager head);


 
}
