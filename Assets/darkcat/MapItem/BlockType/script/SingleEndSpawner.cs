using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SingleEndSpawner", menuName = "Block/SingleEndSpawner")]
public class SingleEndSpawner : Block
{
    public GameObject[] EndPattern1 = new GameObject[2];
    public GameObject[] EndPattern2 = new GameObject[2];
    public void OnSpawnEndPoint()
    {

    }
}
