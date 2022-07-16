using System.Collections;
using System.Collections.Generic;
using SonaruUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimerTest : MonoBehaviour
{
    public SimpleTimer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = new SimpleTimer(100);
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame) timer.Reduce(3);
        
        Debug.Log(timer.Remain01);
    }
}
