using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.name == "Character_1_mod"|| Player.gameObject.name == "Character_2_mod")
        {
            GameObject.Find("GameController").GetComponent<GameController>().Player1.ChangeColor();
            GameObject.Find("GameController").GetComponent<GameController>().Player2.ChangeColor();
        }    
    }
}
