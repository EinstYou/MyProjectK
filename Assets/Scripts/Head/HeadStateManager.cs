using UnityEngine;

public class HeadStateManager : MonoBehaviour
{

    HeadBaseState currentState;
    HeadStandState StandState = new HeadStandState();
    HeadNormalState NormalState = new HeadNormalState();
    HeadThrowingState ThrowingState = new HeadThrowingState();

    void Start()
    {
        currentState = NormalState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
