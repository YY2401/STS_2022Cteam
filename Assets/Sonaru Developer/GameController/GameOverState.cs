
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
public class GameOverState : IState
{
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        Controller.EndObject.SetActive(true);
        Controller.EndLevel.text = Controller.CurrentRound.ToString();
        Debug.Log($"Game Over !! Total Round: {Controller.CurrentRound}");
    }

    public void OnStateStay()
    {
        foreach (var item in Gamepad.all)
        {
            if (item.buttonEast.wasPressedThisFrame)
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    public void OnStateExit()
    {
        
    }
}
