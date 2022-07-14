using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public enum BlockType
{
    Wall,
    TrapSpawner,
    ColorChangerSpawner,
    SingleEndSpawner,
    DoubleEndSpawner,
    Road,

}
public abstract class Block : ScriptableObject
{
    public BlockType ThisBlockType;
    public GameObject Prefab;    
    public UnityEvent Spawn_event = new UnityEvent();
    public UnityEvent Hit_event = new UnityEvent();
    public void SpawnBlock(int COL,int ROW)
    {
        //依據Pos去生成Prefab
    }
}
