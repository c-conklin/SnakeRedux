using _Scripts;
using _Scripts.Extensions;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameGrid _gameGrid;
    [SerializeField] private Transform cam;
    
    public GameGrid GameGrid => _gameGrid;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Initialize the grid
        _gameGrid.Init(transform);
        
        // Log out each grid cell's position
        _gameGrid.LogGrid();
        
        // Move camera to center of grid
        cam.position = _gameGrid.GetGridCenter();
    }
}
