using System.Collections.Generic;
using System.Linq;
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
    
    public MapSO TargetMap;

    public List<BlockType> AllBlockType;
    private int ColNum;
    private int RowNum;
    
    [MenuItem("Map/MapEditorWindow")]
    private static void ShowWindow()
    {
        var window = GetWindow<MapEditorWindow>();
        window.titleContent = new GUIContent("Map Window");
        window.Show();
    }

    private void OnGUI()
    {
        // CCS = (ColorChangerSpawner) EditorGUILayout.ObjectField("ColorChangeSpawner", CCS, typeof(Block), true);
        // DES = (DoubleEndSpawner) EditorGUILayout.ObjectField("DoubleEndSpawner", DES, typeof(Block), true);
        // SES = (SingleEndSpawner) EditorGUILayout.ObjectField("SingleEndSpawner", SES, typeof(Block), true);
        // TS = (TrapSpawner) EditorGUILayout.ObjectField("TrapSpawner", TS, typeof(Block), true);
        // RD = (Road) EditorGUILayout.ObjectField("Road", RD, typeof(Block), true);
        // WL = (Wall) EditorGUILayout.ObjectField("Wall", WL, typeof(Block), true);
        
        TargetMap = (MapSO)EditorGUILayout.ObjectField("Map", TargetMap, typeof(MapSO), true);
        
        if(TargetMap == null)
        {
            Repaint();
            return;
        }

        AllBlockType = new List<BlockType>();
        
        ColNum = TargetMap.ThisMap.Count;
        RowNum = TargetMap.ThisMap[0].ThisColumn.Count;

        for (var i = TargetMap.ThisMap.Count - 1; i >= 0; i--)
        {
            GUILayout.BeginHorizontal();
            foreach (var block in TargetMap.ThisMap[i].ThisColumn)
            {
                var enumPopup = (BlockType) EditorGUILayout.EnumPopup(block.ThisBlockType);
            }
            GUILayout.EndHorizontal();
        }

    }
}
