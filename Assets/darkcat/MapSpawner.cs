using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public NowMapData MapData;
    public MapSO MapPreMade;
    public List<Vector2> TrapPos = new List<Vector2>();
    public List<Vector2> ColorChanger = new List<Vector2>();
    public List<Vector2> EndPos = new List<Vector2>();
    void Start()
    {
        SpawnMap(1);
        
        MapListToScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnMap(int Round)
    {
        if (Round%2 == 1)
        {
            //單回合
            for (int i = 0; i < MapPreMade.ThisMap.Count; i++)
            {
                for (int j = 0; j < MapPreMade.ThisMap[i].ThisColumn.Count; j++)
                {
                    Debug.Log(i.ToString()+j.ToString());
                    switch (MapPreMade.ThisMap[i].ThisColumn[j].ThisBlockType)
                    {
                        case BlockType.Wall:
                            MapData.ThisColumnData[i].ThisBlockData[j]=((MapPreMade.ThisMap[i].ThisColumn[j].ThisBlockType));                            
                            break;
                        case BlockType.Road:
                            MapData.ThisColumnData[i].ThisBlockData[j] = ((MapPreMade.ThisMap[i].ThisColumn[j].ThisBlockType));
                            break;
                        case BlockType.TrapSpawner:
                            TrapPos.Add(new Vector2(i, j));
                            MapData.ThisColumnData[i].ThisBlockData[j] = (BlockType.Road);
                            break;
                        case BlockType.ColorChangerSpawner:
                            ColorChanger.Add(new Vector2(i, j));
                            MapData.ThisColumnData[i].ThisBlockData[j] = (BlockType.Road);
                            break;
                        case BlockType.SingleEndSpawner:
                            EndPos.Add(new Vector2(i, j));
                            MapData.ThisColumnData[i].ThisBlockData[j] = (BlockType.Road);
                            break;
                        case BlockType.DoubleEndSpawner:
                            MapData.ThisColumnData[i].ThisBlockData[j] = (BlockType.Road);
                            break;
                    }
                }
            }
            for (int i = 0; i < 12; i++)
            {
                int r = Random.Range(0, TrapPos.Count);
                int a = Random.Range(0, 3);
                switch (a)
                {
                    case 0:
                        MapData.ThisColumnData[(int)TrapPos[r].x].ThisBlockData[(int)TrapPos[r].y] = BlockType.FireTrap;
                        break;
                    case 1:
                        MapData.ThisColumnData[(int)TrapPos[r].x].ThisBlockData[(int)TrapPos[r].y] = BlockType.ThunderTrap;
                        break;
                    case 2:
                        MapData.ThisColumnData[(int)TrapPos[r].x].ThisBlockData[(int)TrapPos[r].y] = BlockType.MistTrap;
                        break;
                }
                TrapPos.RemoveAt(r);
            }
            for (int i = 0; i < 2; i++)
            {
                int r = Random.Range(0, ColorChanger.Count);
                MapData.ThisColumnData[(int)ColorChanger[r].x].ThisBlockData[(int)ColorChanger[r].y] = BlockType.ColorChanger;
                ColorChanger.RemoveAt(r);
            }
            for (int i = 0; i < 2; i++)
            {
                int r = Random.Range(0, EndPos.Count);
                Debug.Log(r);
                MapData.ThisColumnData[(int)EndPos[r].x].ThisBlockData[(int)EndPos[r].y] = BlockType.End;
                EndPos.RemoveAt(r);
            }
        }
        else
        {
            //雙回合
            for (int i = 0; i < MapPreMade.ThisMap.Count; i++)
            {
                for (int j = 0; j < MapPreMade.ThisMap[i].ThisColumn.Count; j++)
                {
                    Debug.Log(i.ToString() + j.ToString());
                    switch (MapPreMade.ThisMap[i].ThisColumn[j].ThisBlockType)
                    {
                        case BlockType.Wall:
                            MapData.ThisColumnData[i].ThisBlockData[j] = ((MapPreMade.ThisMap[i].ThisColumn[j].ThisBlockType));
                            break;
                        case BlockType.Road:
                            MapData.ThisColumnData[i].ThisBlockData[j] = ((MapPreMade.ThisMap[i].ThisColumn[j].ThisBlockType));
                            break;
                        case BlockType.TrapSpawner:
                            TrapPos.Add(new Vector2(i, j));
                            MapData.ThisColumnData[i].ThisBlockData[j] = (BlockType.Road);
                            break;
                        case BlockType.ColorChangerSpawner:
                            ColorChanger.Add(new Vector2(i, j));
                            MapData.ThisColumnData[i].ThisBlockData[j] = (BlockType.Road);
                            break;
                        case BlockType.DoubleEndSpawner:
                            EndPos.Add(new Vector2(i, j));
                            MapData.ThisColumnData[i].ThisBlockData[j] = (BlockType.Road);
                            break;
                        case BlockType.SingleEndSpawner:
                            MapData.ThisColumnData[i].ThisBlockData[j] = (BlockType.Road);
                            break;
                    }
                }
            }
            for (int i = 0; i < 12; i++)
            {
                int r = Random.Range(0, TrapPos.Count);
                int a = Random.Range(0, 3);
                switch (a)
                {
                    case 0:
                        MapData.ThisColumnData[(int)TrapPos[r].x].ThisBlockData[(int)TrapPos[r].y] = BlockType.FireTrap;
                        break;
                    case 1:
                        MapData.ThisColumnData[(int)TrapPos[r].x].ThisBlockData[(int)TrapPos[r].y] = BlockType.ThunderTrap;
                        break;
                    case 2:
                        MapData.ThisColumnData[(int)TrapPos[r].x].ThisBlockData[(int)TrapPos[r].y] = BlockType.MistTrap;
                        break;
                }
                TrapPos.RemoveAt(r);
            }
            for (int i = 0; i < 2; i++)
            {
                int r = Random.Range(0, ColorChanger.Count);
                MapData.ThisColumnData[(int)ColorChanger[r].x].ThisBlockData[(int)ColorChanger[r].y] = BlockType.ColorChanger;
                ColorChanger.RemoveAt(r);
            }
            for (int i = 0; i < 2; i++)
            {
                int r = Random.Range(0, EndPos.Count);
                Debug.Log(r);
                MapData.ThisColumnData[(int)EndPos[r].x].ThisBlockData[(int)EndPos[r].y] = BlockType.End;
                EndPos.RemoveAt(r);
            }
        }        
    }
    public void MapListToScene()
    {
        for (int i = 1; i < 8; i++)
        {
            for (int j = 1; j < 8; j++)
            {
                //switch(MapData.NowMap[i][j])
                //{
                //    case BlockType.Wall:
                //}
                //Debug.Log(i.ToString() + j.ToString() + MapData.ThisColumnData[i].ThisBlockData[j].ToString());
            }
        }
    }
}
