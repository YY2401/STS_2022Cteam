using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OntriggerMist : MonoBehaviour
{
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.name == "Character_1_mod" || Player.gameObject.name == "Character_2_mod")
        {
            SEManager.instance.OnMist();
            Player.GetComponent<Move>().OnMistTrigger();
        }
    }
}
