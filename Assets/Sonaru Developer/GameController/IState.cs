using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    GameController Controller { get; set; }
    void OnStateEnter(GameController controller);
    void OnStateStay();
    void OnStateExit();
}
