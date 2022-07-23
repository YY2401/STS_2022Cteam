using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class StaffContinue : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        foreach (var item in Gamepad.all)
        {
            if (item.buttonEast.wasPressedThisFrame)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
