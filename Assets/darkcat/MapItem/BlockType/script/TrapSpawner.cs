using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrapSpawner", menuName = "Block/TrapSpawner")]
public class TrapSpawner : Block
{
    public List<GameObject> TrapPrefabs = new List<GameObject>();
    public void RandomSpawnTrap()
    {

    }
}
