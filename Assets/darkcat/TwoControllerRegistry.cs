using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class TwoControllerRegistry : MonoBehaviour
{
    public static TwoControllerRegistry instance;
    public GamePadRes Player1;
    public GamePadRes Player2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1.isChecked && Player2.isChecked)
        {
            
        }
        //production
        foreach (Gamepad g in Gamepad.all)
        {
            if (Player1.isChecked && Player2.isChecked)
            {
                if (g.rightTrigger.isPressed || g.leftTrigger.isPressed)
                {
                    Debug.Log("next scene");
                    SceneManager.LoadScene("Main");
                }
            }
        }
    }
}
