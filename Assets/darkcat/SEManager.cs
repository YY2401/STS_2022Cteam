using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager instance;
    public GameObject PressedButton;
    public GameObject FireSE;
    public GameObject MistSE;
    public GameObject LightingSE;
    public GameObject ColorChanger;
    private void Awake()
    {
        instance = this;
    }
    public void OnMove()
    {
        Instantiate(PressedButton);
    }
    public void OnFire()
    {
        Instantiate(FireSE);
    }
    public void OnMist()
    {
        Instantiate(MistSE);
    }
    public void OnLighting()
    {
        Instantiate(LightingSE);
    }
    public void OnColor()
    {
        Instantiate(ColorChanger);
    }    
}
