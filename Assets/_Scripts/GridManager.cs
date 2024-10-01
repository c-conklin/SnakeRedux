using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int GridHeight;
    [SerializeField] private int GridWidth;
    [SerializeField] private int CellSize;
    [SerializeField] private Transform cam;
    [SerializeField] private GridCell _gridCellPrefab;
    
    public int GetGridHeight()
    {
        return GridHeight;
    }
    
    public int GetGridWidth()
    {
        return GridWidth;
    }

    public Vector3[,] Grid;
    
    // Start is called before the first frame update
    void Start()
    {
        Grid = new Vector3[GridWidth + 1, GridHeight + 1];
        CreateGrid();
        
        
        for (var heightIdx = 0; heightIdx <= GridHeight; heightIdx++)
        {
            for (var widthIdx = 0; widthIdx <= GridWidth; widthIdx++)
            {
                Debug.Log($"Grid[{widthIdx}, {heightIdx}] = {Grid[widthIdx, heightIdx]}");
            }
        }
    }

    void CreateGrid()
    { 
        
        for (var heightIdx = 0; heightIdx <= GridHeight; heightIdx++)
        {
            for (var widthIdx = 0; widthIdx <= GridWidth; widthIdx++)
            {
                GridCell gridCell = Instantiate<GridCell>(_gridCellPrefab, new Vector3(x: widthIdx, y: heightIdx, z: 0), Quaternion.identity);
                
                gridCell.name = $"Cell_{widthIdx}_{heightIdx}";
                gridCell.transform.localScale = new Vector3(CellSize, CellSize, 1);
                cam.transform.position = new Vector3((float)GridWidth / 2, (float)GridHeight / 2, -10);
                Grid[widthIdx, heightIdx] = gridCell.transform.position;
                // Set the parent of the grid cell to the GridManager
                gridCell.transform.SetParent(transform);
                
                var isOffset = (widthIdx % 2 == 0 && heightIdx % 2 != 0) || (widthIdx % 2 != 0 && heightIdx % 2 == 0);
                
                gridCell.Init(isOffset);
            }
        }
    }
    
    
}
