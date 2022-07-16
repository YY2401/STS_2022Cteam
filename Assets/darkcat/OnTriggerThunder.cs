using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerThunder : MonoBehaviour
{
    public GameObject ThunderParticle;
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.name == "Character_1_mod" || Player.gameObject.name == "Character_2_mod")
        {
            SEManager.instance.OnLighting();
            Player.GetComponent<Move>().OnThunderTrigger(ThunderParticle);            
        }
    }
}
