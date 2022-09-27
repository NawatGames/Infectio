using UnityEngine;

public abstract class AreaBaseState
{
    public abstract void EnterState(AreaStateManager area);

    public abstract void UpdateState(AreaStateManager area);

}
