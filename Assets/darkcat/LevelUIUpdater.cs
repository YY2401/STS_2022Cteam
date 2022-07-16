using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIUpdater : MonoBehaviour
{
    public Text LevelText;
    public GameController GM;
    private void Update()
    {
        LevelText.text = GM.CurrentRound.ToString();
    }
}
