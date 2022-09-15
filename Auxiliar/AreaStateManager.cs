using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaStateManager : MonoBehaviour
{
    public AreaBaseState _currentState;
    public UncontaminatedArea _uncontaminatedState = new UncontaminatedArea();
    public ContaminatedArea _contaminatedState = new ContaminatedArea();
    public DominatedArea _dominatedState = new DominatedArea();
    public ViralCradle _viralCradleState = new ViralCradle();
    
    void Start()
    {
        _currentState = _uncontaminatedState;

        _currentState.EnterState(this);        
    }

   
    void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(AreaBaseState state)
    {
        _currentState = state;
        state.EnterState(this);

    }
}
