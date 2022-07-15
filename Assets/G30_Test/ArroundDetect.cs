using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArroundDetect : MonoBehaviour
{
    public GameObject Player_1P;
    public GameObject Player_2P;
    
    void Start()
    {
        Player_1P = GameObject.Find("Character_1_mod");
        Player_2P = GameObject.Find("Character_2_mod");
    }


    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Character_2_mod")
        //偵測周遭有沒有碰到玩家
        {
            switch(this.gameObject.name)
            {
                case "Forward_1P":
                    Debug.Log("Forward");
                    //Player_1P.GetComponent<Move>().IsPlayer[0] = true;
                break;

                case "Right_1P":
                    Debug.Log("Right");
                    //Player_1P.GetComponent<Move>().IsPlayer[3] = true;
                break;

                case "Back_1P":
                    Debug.Log("Back");
                    //Player_1P.GetComponent<Move>().IsPlayer[1] = true;
                break;

                case "Left_1P":
                    Debug.Log("Left");
                    //Player_1P.GetComponent<Move>().IsPlayer[2] = true;
                break;

            }
        }
        else
        {
            // Player_1P.GetComponent<Move>().IsPlayer[0] = false;
            // Player_1P.GetComponent<Move>().IsPlayer[1] = false;
            // Player_1P.GetComponent<Move>().IsPlayer[2] = false;
            // Player_1P.GetComponent<Move>().IsPlayer[3] = false;
        }
    }
}
