using UnityEngine;

public class ViralCradle : AreaBaseState
{

    public InfoScript info = new InfoScript();
    public override void EnterState(AreaStateManager area)
    {
        info.stateControl++;
        info.nucleotides += 5;
        info.grossFee += 2;
        info.cureFee -= 1;
    }

    public override void UpdateState(AreaStateManager area)
    {
      
    }
}
