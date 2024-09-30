using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int GridHeight;
    [SerializeField] private int GridWidth;
    [SerializeField] private int CellSize;
    [SerializeField] private GameObject CellPrefab;
    [SerializeField] private Transform cam;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (var heightIdx = 0; heightIdx < GridHeight; heightIdx++)
        {
            for (var widthIdx = 0; widthIdx < GridWidth; widthIdx++)
            {
                GameObject gridCell = Instantiate(CellPrefab, new Vector3(x: widthIdx, y: heightIdx, z: 0), Quaternion.identity);
                gridCell.name = $"Cell_{widthIdx}_{heightIdx}";
                
                gridCell.transform.localScale = new Vector3(CellSize, CellSize, 1);
                
                cam.transform.position = new Vector3((float)GridWidth / 2 - 0.5f, (float)GridHeight / 2 - 0.5f, -10);
                
                // Set the parent of the grid cell to the GridManager
                gridCell.transform.SetParent(transform);
            }
        }
    }
    
    
}
