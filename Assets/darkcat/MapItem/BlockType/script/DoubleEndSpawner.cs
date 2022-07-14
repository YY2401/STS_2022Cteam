using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoubleEndSpawner", menuName = "Block/DoubleEndSpawner")]

public class DoubleEndSpawner : Block
{
    public GameObject[] EndPattern1 = new GameObject[2];
    public GameObject[] EndPattern2 = new GameObject[2];
    public void OnSpawnEnd()
    {

    }
}
