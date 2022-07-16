
using UnityEngine;

public class GameOverState : IState
{
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        
        Debug.Log($"Game Over !! Total Round: {Controller.CurrentRound}");
    }

    public void OnStateStay()
    {
        
    }

    public void OnStateExit()
    {
        
    }
}
