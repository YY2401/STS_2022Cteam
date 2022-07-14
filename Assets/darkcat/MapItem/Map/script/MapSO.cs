using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "MapSO")]
public class MapSO : ScriptableObject
{
    public List<ColumnSO> ThisMap = new List<ColumnSO>();    
}
