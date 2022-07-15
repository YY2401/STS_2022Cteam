using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArroundDetect : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Character_2_mod")
        {
            Debug.Log("CC");
            if(this.gameObject.name == "Forward")
            {
                Debug.Log("Forward");
            }
            else if(this.gameObject.name == "Right")
            {
                Debug.Log("CCC");
            }
            else if(this.gameObject.name == "Back")
            {
                Debug.Log("CCC");
            }
            else if(this.gameObject.name == "Left")
            {
                Debug.Log("CCC");
            }
        }
    }
}
