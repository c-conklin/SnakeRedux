using UnityEngine;

namespace _Scripts.Extensions
{
    public static class GameGridExtensions
    {
        public static Vector3 GetWorldPosition(this GameGrid grid, int x, int y)
        {
            return new Vector3(x, y) * grid.CellSize;
        }
        
        public static void LogGrid(this GameGrid grid)
        {
            for (var heightIdx = 0; heightIdx <= grid.GridHeight; heightIdx++)
            {
                for (var widthIdx = 0; widthIdx <= grid.GridWidth; widthIdx++)
                {
                    Debug.Log($"Grid[{widthIdx}, {heightIdx}] = {grid.GetWorldPosition(widthIdx, heightIdx)}");
                }
            }
        }
        
        public static Vector3 GetGridCenter(this GameGrid grid)
        {
            return new Vector3(grid.GridWidth / 2, grid.GridHeight / 2, -10);
        }
        
        public static bool IsWithinGrid(this GameGrid grid, int x, int y)
        {
            return x >= 0 && x <= grid.GridWidth && y >= 0 && y <= grid.GridHeight;
        }
    }
}
