
using UnityEngine;
using UnityEngine.AddressableAssets;

public class StageStartState : IState
{
    public GameController Controller { get; set; }
    
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        
        Controller.MapControl.LoadBlockAssetData();
        
        Controller.DelayDo(()=>Controller.ChangeState(StateEnum.MainPlay), 3);
    }

    public void OnStateStay()
    {
        
    }

    public void OnStateExit()
    {
        
    }
}
