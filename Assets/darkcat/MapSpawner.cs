using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class MapSpawner : MonoBehaviour
{
    public NowMapData MapData;
    public MapSO MapPreMade;
    private List<Vector2> TrapPos = new List<Vector2>();
    private List<Vector2> ColorChanger = new List<Vector2>();
    public List<Vector2> EndPos = new List<Vector2>();
    public GameObject[] EndBlock;
    public IList<GameObject> m_Blocks;
    public AssetLabelReference m_BlocksLables;
    private List<GameObject> Floors = new List<GameObject>();
    void Start()
    {
        LoadBlockAssetData();
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (var item in Gamepad.all)
        //{
        //    if (item.buttonEast.wasPressedThisFrame)
        //    {
        //        DestroyMap();
        //        SpawnMap(1);
        //        MapListToScene();
        //    }
        //    if (item.buttonNorth.wasPressedThisFrame)
        //    {
        //        DestroyMap();
        //        SpawnMap(2);
        //        MapListToScene();
        //    }

        //}
    }
    public void OnResourcesRetrived(AsyncOperationHandle<IList<GameObject>>obj)
    {
        m_Blocks = obj.Result;
        Debug.Log("LoadComplete");
        SpawnMap(1);
        MapListToScene();
    }
    public void LoadBlockAssetData()
    {
        Addressables.LoadAssetsAsync<GameObject>(m_BlocksLables, null).Completed += OnResourcesRetrived;
    }
    public void SpawnMap(int Round)
    {
        TrapPos.Clear();
        ColorChanger.Clear();
        EndPos.Clear();
        if (Round%2 == 1)
        {
            //單回合
            for (int i = 0; i < MapPreMade.ThisMap.Count; i++)
            {
                for (int j = 0; j < MapPreMade.ThisMap[i].ThisColumn.Count; j++)
                {
                    //Debug.Log(i.ToString()+j.ToString());
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
                //Debug.LogError(EndPos[r]);
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
                Debug.LogWarning(EndPos[r]);
                MapData.ThisColumnData[(int)EndPos[r].x].ThisBlockData[(int)EndPos[r].y] = BlockType.End;
                EndPos.RemoveAt(r);
            }
        }        
    }
    public BlockType GetType(Vector2 pos)
    {
        return MapData.ThisColumnData[(int)pos.x].ThisBlockData[(int)pos.y];
    }
    public GameObject FindAsset(string BlockName)
    {
        foreach (var item in m_Blocks)
        {
            if (item.name == BlockName)
            {
                return item;
            }
        }
        return null;
    }
    public void MapListToScene()
    {
        int Pattern = Random.Range(0, 2);
        bool BoxSpawn = false;
        for (int i = 1; i < 8; i++)
        {
            for (int j = 1; j < 8; j++)
            {
                switch (MapData.ThisColumnData[i].ThisBlockData[j])
                {
                    case BlockType.Road:
                        int rr = Random.Range(0, 3);
                        Floors.Add( Instantiate(FindAsset("Floor"+rr), new Vector3(-2 * (i - 1), -2, -2 * (j - 1)),Quaternion.identity));
                        break;
                    case BlockType.FireTrap:
                        Floors.Add(Instantiate(FindAsset("FireTrap"), new Vector3(-2 * (i - 1), -2, -2 * (j - 1)), Quaternion.Euler(0, 90, 0)));
                        break;
                    case BlockType.ThunderTrap:
                        Floors.Add(Instantiate(FindAsset("LightingTrap"), new Vector3(-2 * (i - 1), -2, -2 * (j - 1)), Quaternion.Euler(0, 90, 0)));
                        break;
                    case BlockType.MistTrap:
                        Floors.Add(Instantiate(FindAsset("MistTrap"), new Vector3(-2 * (i - 1), -2, -2 * (j - 1)), Quaternion.Euler(0, 90, 0)));
                        break;
                    case BlockType.ColorChanger:
                        break;
                    case BlockType.End:
                        if (Pattern == 0)
                        {
                            if (BoxSpawn)
                            {
                                Floors.Add(Instantiate(FindAsset("EndPoint_BlueSquare"), new Vector3(-2 * (i - 1), -2, -2 * (j - 1)), Quaternion.Euler(0, 90, 0)));
                            }
                            else
                            {
                                Floors.Add(Instantiate(FindAsset("EndPoint_RedHolo"), new Vector3(-2 * (i - 1), -2, -2 * (j - 1)), Quaternion.Euler(0, 90, 0)));
                                BoxSpawn = true;
                            }
                        }
                        else
                        {
                            if (BoxSpawn)
                            {
                                Floors.Add(Instantiate(FindAsset("EndPoint_RedSquare"), new Vector3(-2 * (i - 1), -2, -2 * (j - 1)), Quaternion.Euler(0, 90, 0)));
                            }
                            else
                            {
                                Floors.Add(Instantiate(FindAsset("EndPoint_BlueHolo"), new Vector3(-2 * (i - 1), -2, -2 * (j - 1)), Quaternion.Euler(0, 90, 0)));
                                BoxSpawn = true;
                            }
                        }
                        break;
                }
                //Debug.Log(i.ToString() + j.ToString() + MapData.ThisColumnData[i].ThisBlockData[j].ToString());
            }
        }
    }
    public void DestroyMap()
    {
        foreach (var item in Floors)
        {
            Destroy(item);
        }
    }
}
