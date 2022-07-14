
using SonaruUtilities;
using TMPro;
using UnityEngine;

public class MainPlayState : IState
{
    public GameController Controller { get; set; }
    private SimpleTimer gameTimer;

    private TextMesh debugText = null;
    
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        
        Controller.CurrentRound++;
        
        Controller.DelayDo(StartStageSetting, 1);
    }

    public void OnStateStay()
    {
        if(debugText) debugText.text = gameTimer.Remain.ToString();
        
        if(gameTimer.IsFinish) Controller.ChangeState(StateEnum.MainPlay);
    }

    public void OnStateExit()
    {
        Object.Destroy(debugText.gameObject);
    }


    private void StartStageSetting()
    {
        // Set timer
        if (gameTimer == null) gameTimer = new SimpleTimer(Controller.currentRoundCountDown);
        else gameTimer.Reset(Controller.currentRoundCountDown);
        
        debugText = DebugTextMesh.CreatWorldText(gameTimer.Remain.ToString(), Controller.transform, Vector3.zero, 20, Color.red);
    }
}
