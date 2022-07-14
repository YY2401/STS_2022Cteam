using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NowMapData
{
    public MapColunm[] ThisColumnData = new MapColunm[9];
}
[System.Serializable]
public class MapColunm
{
    public BlockType[] ThisBlockData = new BlockType[9];
}
