
using SonaruUtilities;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class StageStartState : IState
{
    public GameController Controller { get; set; }
    private SimpleTimer startTimer;
    
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        
        Controller.MapControl.LoadBlockAssetData();
        startTimer = new SimpleTimer(3);
        // Controller.DelayDo(()=>Controller.ChangeState(StateEnum.MainPlay), 3);
    }

    public void OnStateStay()
    {
        if (startTimer.IsFinish) Controller.ChangeState(StateEnum.MainPlay);
    }

    public void OnStateExit()
    {
        
    }
}
