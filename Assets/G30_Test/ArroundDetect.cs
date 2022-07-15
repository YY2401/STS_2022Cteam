using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArroundDetect : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Character_2_mod")
        //偵測周遭有沒有碰到玩家
        {
            switch(this.gameObject.name)
            {
                case "Forward":
                    Debug.Log("Forward");
                break;

                case "Right":
                    Debug.Log("Right");
                break;

                case "Back":
                    Debug.Log("Back");
                break;

                case "Left":
                    Debug.Log("Left");
                break;

            }
            // if(this.gameObject.name == "Forward")//前方
            // {
            //     Debug.Log("Forward");
            // }
            // else if(this.gameObject.name == "Right")//右方
            // {
            //     Debug.Log("Right");
            // }
            // else if(this.gameObject.name == "Back")//後方
            // {
            //     Debug.Log("Back");
            // }
            // else if(this.gameObject.name == "Left")//左方
            // {
            //     Debug.Log("Left");
            // }
        }
    }
}
