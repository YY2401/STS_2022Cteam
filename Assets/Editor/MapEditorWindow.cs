using System.Collections.Generic;
using System.Linq;
using Sonaru_Developer.MapEditor;
using UnityEditor;
using UnityEngine;



public class MapEditorWindow : EditorWindow
{
    // public ColorChangerSpawner CCS;
    // public DoubleEndSpawner DES;
    // public SingleEndSpawner SES;
    // public TrapSpawner TS;
    // public Road RD;
    // public Wall WL;

    public AllBlockData BlockData;
    public MapSO TargetMap;

    private Dictionary<int, Dictionary<int, Block>> AllBlock;
    private int ColNum;
    private int RowNum;

    private Color CCS_Color = Color.red;
    private Color DES_Color = Color.green;
    private Color SES_Color = Color.magenta;
    private Color TS_Color = Color.cyan;
    private Color RD_Color = Color.gray;
    private Color WL_Color = Color.black;
    
    [MenuItem("Map/MapEditorWindow")]
    private static void ShowWindow()
    {
        var window = GetWindow<MapEditorWindow>();
        window.titleContent = new GUIContent("Map Window");
        window.Show();
    }

    private void OnGUI()
    {
        BlockData = (AllBlockData) EditorGUILayout.ObjectField("AllBlockType", BlockData, typeof(AllBlockData), true);
        TargetMap = (MapSO)EditorGUILayout.ObjectField("Map", TargetMap, typeof(MapSO), true);
        
        if(TargetMap == null || BlockData == null)
        {
            Repaint();
            return;
        }


        AllBlock = new Dictionary<int, Dictionary<int, Block>>();
        ColNum = TargetMap.ThisMap.Count;
        RowNum = TargetMap.ThisMap[0].ThisColumn.Count;

        for (var i = 0; i < TargetMap.ThisMap.Count; i++)
        {
            AllBlock.Add(i, new Dictionary<int, Block>());
            
            GUILayout.BeginHorizontal();
            
            for (var j = 0; j < TargetMap.ThisMap[i].ThisColumn.Count; j++)
            {
                var block = TargetMap.ThisMap[i].ThisColumn[j];
                var enumPopup = (BlockType) EditorGUILayout.EnumPopup(block.ThisBlockType);
                AllBlock[i].Add(j, block);

                switch (enumPopup)
                {
                    case BlockType.ColorChangerSpawner:
                        DrawGridBlock(i*30, j*30, 30, CCS_Color);
                        AllBlock[i][j] = BlockData.CCS;
                        break;
                    case BlockType.DoubleEndSpawner:
                        DrawGridBlock(i*30, j*30, 30, DES_Color);
                        AllBlock[i][j] = BlockData.DES;
                        break;
                    case BlockType.SingleEndSpawner:
                        DrawGridBlock(i*30, j*30, 30, SES_Color);
                        AllBlock[i][j] = BlockData.SES;
                        break;
                    case BlockType.TrapSpawner:
                        DrawGridBlock(i*30, j*30, 30, TS_Color);
                        AllBlock[i][j] = BlockData.TS;
                        break;
                    case BlockType.Road:
                        DrawGridBlock(i*30, j*30, 30, RD_Color);
                        AllBlock[i][j] = BlockData.RD;
                        break;
                    case BlockType.Wall:
                        DrawGridBlock(i*30, j*30, 30, WL_Color);
                        AllBlock[i][j] = BlockData.WL;
                        break;
                }
                
                TargetMap.ThisMap[i].ThisColumn[j] = AllBlock[i][j];
                EditorUtility.SetDirty(TargetMap);
            }
            
            GUILayout.EndHorizontal();
        }

        GUILayout.MinWidth(200);
    }
    
    
    public void DrawGridBlock(int x, int y, int width, Color color) {
        Rect rect = new Rect(x, y, width, width);
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.Box(rect, GUIContent.none);
    }
}
