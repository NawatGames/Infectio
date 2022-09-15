
using UnityEngine;

public class UncontaminatedArea : AreaBaseState
{

    public InfoScript info = new InfoScript();
    public BoardManager boardManager = new BoardManager();

    public override void EnterState(AreaStateManager area)
    {
        info.stateControl++;
        Debug.Log("Hello from the uncontaminated state !");
    }
    
    public override void UpdateState(AreaStateManager area)
    {
        if (Input.GetKeyDown("space"))
        {
            if (area.transform.position == boardManager.indicatorInstance.transform.position)
            {
                area.SwitchState(area._contaminatedState);
            }
        }
    }


}
