using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Game/Level Data", order = 0)]
    public class LevelDataSO : ScriptableObject
    {
        public int width = 16;
        public int height = 9;
        public int CellSize = 1;
        public List<TileData> tiles = new();
        
        [System.Serializable]
        public class TileData
        {
            public bool hasObstacle;
            public LevelTileType levelTileType; 
            public Vector2Int position;
        }

        public int minX => CellSize;
        public int maxX => width - CellSize;
        public int minY => CellSize;
        public int maxY => height - CellSize;
    }
    
    public enum LevelTileType
    {
        Ground,
        Hole
    }
}
