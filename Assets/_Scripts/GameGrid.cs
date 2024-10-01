using UnityEngine;

namespace _Scripts
{
    [CreateAssetMenu(fileName = "GameGrid", menuName = "Game/Game Grid", order = 0)]
    public class GameGrid : ScriptableObject
    {
        public int GridHeight;
        public int GridWidth;
        public int CellSize;
        public GameObject GridCellPrefab;
        
        private Vector3[,] _grid;
        
        public void Init(Transform transform)
        {
            _grid = new Vector3[GridWidth + 1, GridHeight + 1];
            CreateGrid(transform);
        }
        
        private static void SetName(GameObject gridCell, int widthIdx, int heightIdx) => gridCell.name = $"Cell_{widthIdx}_{heightIdx}";
        private void SetScale(GameObject gridCell) => gridCell.transform.localScale = new Vector3(CellSize, CellSize, 1);
        private void SetParent(GameObject gridCell, Transform parent) => gridCell.transform.SetParent(parent);
        private void SetPosition(GameObject gridCell, int widthIdx, int heightIdx) => gridCell.transform.position = new Vector3(widthIdx, heightIdx, 0); 
        private void SetGridCell(GameObject gridCell, bool isOffset) => gridCell.GetComponent<GridCell>().Init(isOffset);
        
        public void CreateGrid(Transform parent)
        {
            for (var heightIdx = 0; heightIdx <= GridHeight; heightIdx++)
            {
                for (var widthIdx = 0; widthIdx <= GridWidth; widthIdx++)
                {
                    GameObject gridCell = Instantiate(GridCellPrefab, new Vector3(x: widthIdx, y: heightIdx, z: 0), Quaternion.identity);
                    
                    SetName(gridCell, widthIdx, heightIdx);
                    SetScale(gridCell);
                    SetParent(gridCell, parent);
                    SetPosition(gridCell, widthIdx, heightIdx);
                    _grid[widthIdx, heightIdx] = gridCell.transform.position;
                    
                    var isOffset = (widthIdx % 2 == 0 && heightIdx % 2 != 0) || (widthIdx % 2 != 0 && heightIdx % 2 == 0);
                    
                    SetGridCell(gridCell, isOffset);
                }
            }
        }
    }
}
