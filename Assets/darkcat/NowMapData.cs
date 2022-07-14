using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NowMapData
{
    public List<BlockType> RandomColumn = new List<BlockType>();
    public List<List<BlockType>> NowMap = new List<List<BlockType>>();
}
