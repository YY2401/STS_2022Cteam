
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
        
        //Register Action
        Controller.OnFireTrigger += reduceTime;
    }

    public void OnStateStay()
    {
        Debug.Log(gameTimer.Remain01);
        TimeBar.instance.currentTime =(gameTimer.Remain01);
        // if Time over -> game over scene
        if(gameTimer.IsFinish) Controller.ChangeState(StateEnum.GameOver);
        // else if Player1 & Player2 arrive finish point -> main play scene
        if(AllPlayerArriveFinish()) Controller.ChangeState(StateEnum.MainPlay);
    }

    public void OnStateExit()
    {
        Controller.OnFireTrigger -= reduceTime;
        Controller.MapControl.DestroyMap();
        Controller.Player1.IsToEnd = false;
        Controller.Player2.IsToEnd = false;
        //Object.Destroy(debugText.gameObject);
    }


    private void StartStageSetting()
    {
        Controller.MapControl.SpawnMap(Controller.CurrentRound);
        Controller.MapControl.MapListToScene();
        Controller.Player1.GetComponent<Animator>().enabled = false;
        Controller.Player2.GetComponent<Animator>().enabled = false;
        gameTimer.Resume();
    }

    private bool AllPlayerArriveFinish() =>  Controller.Player1.IsToEnd && Controller.Player2.IsToEnd;

    private void reduceTime(float time)
    {
        gameTimer.Reduce(time);
    }
}
