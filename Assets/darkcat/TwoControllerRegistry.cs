using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TwoControllerRegistry : MonoBehaviour
{
    public static TwoControllerRegistry instance;
    public GamePadRes Player1;
    public GamePadRes Player2;
    public GameObject P1;
    public GameObject P2;
    public GameObject P1Pat;
    public GameObject P2Pat;
    public Animator Camera;
    private void Awake()
    {
        instance = this;
    }
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
            if (Player1.isChecked && Player2.isChecked&&Camera.enabled == false)
            {
                if (g.rightTrigger.isPressed || g.leftTrigger.isPressed)
                {
                    Debug.Log("next scene");
                    Camera.enabled = true;
                    P1.transform.DOMoveY(45, 2f);
                    P2.transform.DOMoveY(45, 2f);
                    
                }
            }
        }
    }
}
