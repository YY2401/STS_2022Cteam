using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


public class darkcattest : MonoBehaviour
{
    private void Update()
    {
        foreach (var g in Gamepad.all)
        {
            if (g.dpad.IsPressed())
            {
                Debug.Log(g.dpad.ReadValue());
            }
        }
    }
}
