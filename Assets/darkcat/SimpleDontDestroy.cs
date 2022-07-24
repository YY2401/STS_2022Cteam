using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDontDestroy : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

   
}
