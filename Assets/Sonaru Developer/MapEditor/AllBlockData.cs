using UnityEngine;

namespace Sonaru_Developer.MapEditor
{
    [CreateAssetMenu(fileName = "BlockData", menuName = "AllBlockData")]
    public class AllBlockData : ScriptableObject
    {
        public ColorChangerSpawner CCS;
        public DoubleEndSpawner DES;
        public SingleEndSpawner SES;
        public TrapSpawner TS;
        public Road RD;
        public Wall WL;
    }
}