using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSEAnimation : MonoBehaviour
{
    public GameObject SwordSE;
    
    public void GenSwordSE()
    {
        Instantiate(SwordSE);
    }
}
