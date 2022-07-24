using System;
using System.Collections;
using System.Collections.Generic;
using SonaruUtilities;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject EndObject;
    public Text EndLevel;

    public MapSpawner MapControl;
    public Move Player1;
    public Move Player2;
    
    private int currentRound;

    public event Action<float> OnFireTrigger;

    public int CurrentRound
    {
        get => currentRound;
        set
        {
            calcRoundTime(value);
            currentRound = value;
        }
    }

    public float FirstRoundCountDown;
    public float currentRoundCountDown;

    public StateEnum CurrentState;
    private Dictionary<StateEnum, IState> allState;
    

    void Awake()
    {
        allState = new Dictionary<StateEnum, IState>()
        {
            {StateEnum.StageStart, new StageStartState()},
            {StateEnum.MainPlay, new MainPlayState()},
            {StateEnum.GameOver, new GameOverState()}
        };
        
        ChangeState(StateEnum.StageStart);
        calcRoundTime(1);
    }

    // Update is called once per frame
    void Update()
    {
        allState[CurrentState]?.OnStateStay();
    }


    public void ChangeState(StateEnum newState)
    {
        allState[CurrentState]?.OnStateExit();
        CurrentState = newState;
        allState[CurrentState]?.OnStateEnter(this);
    }

    public void ReducePlayTimer(float time)
    {
        OnFireTrigger?.Invoke(time);         
    }

    private void calcRoundTime(int round) => currentRoundCountDown = Mathf.Max(FirstRoundCountDown - round + 1, 6.5f);


    #region Delay Do Something Function

    public void DelayDo(Action onComplete, float delay)
    {
        StartCoroutine(DelayDoInner(delay, onComplete));
    }

    public void DelayDo<T>(Action<T> onComplete, T param1, float delay)
    {
        StartCoroutine(DelayDoInner<T>(delay, onComplete, param1));
    }

    private IEnumerator DelayDoInner(float delay, Action onComplete = null)
    {
        yield return new WaitForSeconds(delay);
        
        onComplete?.Invoke();
    }

    private IEnumerator DelayDoInner<T>(float delay, Action<T> onComplete, T param1)
    {
        yield return new WaitForSeconds(delay);
        
        onComplete?.Invoke(param1);
    }
    
#endregion
}
