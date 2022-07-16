using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using System.Linq;

public class PlayerManager
{
    public static Dictionary<Gamepad, GamePadRes> playerList = new Dictionary<Gamepad, GamePadRes>();
}
public class GamePadRes : MonoBehaviour
{
    public Gamepad _gamepad;
    public enum Check
    {
        circle, cross
    }
    public Check check;
    public bool isChecked = false;
    public DpadControl LeftDpad;
    void Start()
    {
        PlayerManager.playerList.Clear();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChecked)
        {
            foreach (Gamepad g in Gamepad.all)
            {
                if (PlayerManager.playerList.Keys.Contains(g)) continue;
                if (check == Check.circle)
                {
                    if (g.buttonEast.isPressed)
                    {
                        _gamepad = g;
                        isChecked = true;
                        PlayerManager.playerList.Add(g, this);
                        LeftDpad = _gamepad.dpad;
                        TwoControllerRegistry.instance.P1.GetComponent<Animator>().enabled = true;
                        TwoControllerRegistry.instance.P1Pat.SetActive(true);
                        Debug.Log(g.name + ": " + check.ToString());
                        //AudioController.Instance.SpawnSFX(SFXType.CirclePair);
                        return;
                    }
                }
                else if (check == Check.cross)
                {
                    if (g.buttonSouth.isPressed)
                    {
                        _gamepad = g;
                        isChecked = true;
                        PlayerManager.playerList.Add(g, this);
                        LeftDpad = _gamepad.dpad;
                        TwoControllerRegistry.instance.P2.GetComponent<Animator>().enabled = true;
                        TwoControllerRegistry.instance.P2Pat.SetActive(true);
                        Debug.Log(g.name + ": " + check.ToString());
                        //AudioController.Instance.SpawnSFX(SFXType.CrossPair);
                        return;
                    }
                }
            }
            return;
        }
    }
}
