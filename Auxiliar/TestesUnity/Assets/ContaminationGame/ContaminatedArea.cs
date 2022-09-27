using UnityEngine;

public class ContaminatedArea : AreaBaseState
{
    public InfoScript info = new InfoScript();

    public override void EnterState(AreaStateManager area)
    {
        info.stateControl++;
        info.nucleotides += 5;
        info.grossFee += 2;
        info.cureFee -= 1;
        Debug.Log("Hello from the contaminated state!");
        area.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
    }

    public override void UpdateState(AreaStateManager area)
    {
    }
}
