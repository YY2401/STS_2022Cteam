using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject StartSE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in Gamepad.all)
        {
            if (item.buttonEast.wasPressedThisFrame)
            {
                Instantiate(StartSE);
                SceneManager.LoadScene(1);
            }
            if (item.buttonSouth.wasPressedThisFrame)
            {
                Application.Quit();
            }
        }
    }
}
