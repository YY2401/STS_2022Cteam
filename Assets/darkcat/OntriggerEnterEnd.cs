using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OntriggerEnterEnd : MonoBehaviour
{
    public NowColor EndColor;
    public Player EndPlayer;
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.name == "Character_1_mod" || Player.gameObject.name == "Character_2_mod")
        {
            SEManager.instance.OnColor();
        }
    }
    private void OnTriggerStay(Collider Player)
    {
        if (Player.gameObject.name == "Character_1_mod"|| Player.gameObject.name == "Character_2_mod")
        {
            if (Player.GetComponent<Move>().ThisPlayer == EndPlayer&& Player.GetComponent<Move>().ThisColor == EndColor)
            {
                Player.GetComponent<Move>().IsToEnd = true;
            }
        }
    }
    private void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.name == "Character_1_mod" || Player.gameObject.name == "Character_2_mod")
        {            
            Player.GetComponent<Move>().IsToEnd = false;            
        }
    }
}
