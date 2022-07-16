using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGameAnimationController : MonoBehaviour
{
    public GameController GM;
    public Animator SECStage;
    public Animator Logo;
    public Animator Cam;
    private bool IsShaking = true;

    // Update is called once per frame
    void Update()
    {
        if (GM.CurrentRound == 11&&IsShaking)
        {
            Cam.enabled = false;
            InvokeRepeating("CamShakeUpdate", 1, 1.2f);
            IsShaking = false;
        }
        if (GM.CurrentRound>10)
        {            
            Logo.SetBool("Stage3", true);
        }
        else if (GM.CurrentRound > 5)
        {
            SECStage.enabled = true;
            Logo.SetBool("Stage2", true);
        }
    }
    public void CamShakeUpdate()
    {
        Camera.main.DOShakePosition(1, 0.7f, 10);
    }
}
