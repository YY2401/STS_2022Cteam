using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public NowMapData MapData;
    public MapSO MapPreMade;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnMap()
    {
        List<Vector2> TrapPoses = new List<Vector2>();
        List<Vector2> ColorChangers = new List<Vector2>();
        List<Vector2> EndPos = new List<Vector2>();
        if (true)
        {
            //單回合
            for (int i = 0; i < MapPreMade.ThisMap.Count; i++)
            {
                for (int j = 0; j < MapPreMade.ThisMap[i].ThisColumn.Count; j++)
                {
                    switch (MapPreMade.ThisMap[i].ThisColumn[j].ThisBlockType)
                    {
                        case BlockType.Wall:
                            MapData.RandomColumn[j] = (MapPreMade.ThisMap[i].ThisColumn[j].ThisBlockType);
                            break;
                        case BlockType.Road:
                            MapData.RandomColumn[j] = (MapPreMade.ThisMap[i].ThisColumn[j].ThisBlockType);
                            break;
                        case BlockType.TrapSpawner:
                            TrapPoses.Add(new Vector2(i, j));
                            break;
                        case BlockType.ColorChangerSpawner:
                            ColorChangers.Add(new Vector2(i, j));
                            break;
                        case BlockType.SingleEndSpawner:
                            EndPos.Add(new Vector2(i, j));
                            break;
                        case BlockType.DoubleEndSpawner:
                            MapData.RandomColumn[j] = (BlockType.Road);
                            break;
                    }
                    MapData.NowMap.Add(MapData.RandomColumn);
                    MapData.RandomColumn = new List<BlockType>();
                }
            }
            for (int i = 0; i < 12; i++)
            {
                int r = Random.Range(0, 17);
                
                
            }
        }
        else
        {
            //雙回合
        }

        
    }
}
