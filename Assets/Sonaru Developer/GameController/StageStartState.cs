
public class StageStartState : IState
{
    public GameController Controller { get; set; }
    
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;

        Controller.DelayDo(()=>Controller.ChangeState(StateEnum.MainPlay), 1);
    }

    public void OnStateStay()
    {
        
    }

    public void OnStateExit()
    {
        
    }
}
