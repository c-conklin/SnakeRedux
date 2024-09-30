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
    
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (var heightIdx = 0; heightIdx <= GridHeight; heightIdx++)
        {
            for (var widthIdx = 0; widthIdx <= GridWidth; widthIdx++)
            {
                GridCell gridCell = Instantiate(_gridCellPrefab, new Vector3(x: widthIdx, y: heightIdx, z: 0), Quaternion.identity);
                gridCell.name = $"Cell_{widthIdx}_{heightIdx}";
                
                gridCell.transform.localScale = new Vector3(CellSize, CellSize, 1);
                
                cam.transform.position = new Vector3((float)GridWidth / 2, (float)GridHeight / 2, -10);
                // Set the parent of the grid cell to the GridManager
                gridCell.transform.SetParent(transform);
                
                var isOffset = (widthIdx % 2 == 0 && heightIdx % 2 != 0) || (widthIdx % 2 != 0 && heightIdx % 2 == 0);
                
                gridCell.Init(isOffset);
            }
        }
    }
    
    
}
