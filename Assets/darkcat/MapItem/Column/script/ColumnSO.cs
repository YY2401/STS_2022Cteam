using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Column", menuName = "ColumnSO")]
public class ColumnSO : ScriptableObject
{
    public List<Block> ThisColumn = new List<Block>();
}
