
using SonaruUtilities;
using TMPro;
using UnityEngine;

public class MainPlayState : IState
{
    public GameController Controller { get; set; }
    private SimpleTimer gameTimer;

    //private TextMesh debugText = null;
    
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        
        Controller.CurrentRound++;
        //set timer
        // Set timer
        if (gameTimer == null) gameTimer = new SimpleTimer(Controller.currentRoundCountDown);
        else gameTimer.Reset(Controller.currentRoundCountDown);
        gameTimer.Pause();
        
        //debugText = DebugTextMesh.CreatWorldText("", Controller.transform, Vector3.zero, 20, Color.red);
        Controller.DelayDo(StartStageSetting, 1);
    }

    public void OnStateStay()
    {
        // if Time over -> game over scene
        
        // else if Player1 & Player2 arrive finish point -> main play scene
        if(gameTimer.IsFinish) Controller.ChangeState(StateEnum.MainPlay);
    }

    public void OnStateExit()
    {
        Controller.MapControl.DestroyMap();
        //Object.Destroy(debugText.gameObject);
    }


    private void StartStageSetting()
    {
        Controller.MapControl.SpawnMap(Controller.CurrentRound);
        Controller.MapControl.MapListToScene();
        gameTimer.Resume();
    }
}
