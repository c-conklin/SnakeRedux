using System.Collections.Generic;
using System.IO;
using _Scripts;
using _Scripts.Extensions.ScriptableObjectExtensions;
using UnityEngine;
using Bogus;
using JetBrains.Annotations;

public class LevelBuilder : MonoBehaviour
{
    private const float CameraZPosition = -10f;
    private const float ObstacleProbability = 0.1f;
    private const string TileNameFormat = "TILE [{0},{1}]";
    private const string LevelDataFilePath = "/levelData.json";
    public LevelDataSO levelDataSO { get; private set; }
    private string savePath;

    [SerializeField]
    private GameObject groundTilePrefab;
    [SerializeField]
    private GameObject obstaclePrefab;
    private int width => levelDataSO.width;
    private int height => levelDataSO.height;
    private float gridOffset => levelDataSO.CellSize / 2.0f;

    void Start()
    {
        savePath = Application.persistentDataPath + LevelDataFilePath;
        LoadLevel();
        Debug.Log($"GRID OFFSET: {gridOffset}");
        CenterCameraOnLevel();
    }

    public void GenerateLevel()
    {
        levelDataSO = ScriptableObject.CreateInstance<LevelDataSO>();
        var levelDataFaker = CreateTileDataFaker();

        for (int x = 0; x < width; x++)
        {
            for (int y = 1; y <= height; y++)
            {
                Debug.Log($"{y} <= {height}");
                Debug.Log($"X: {x}, Y: {y}");
                var tileData = levelDataFaker.Generate();
                tileData.position = new Vector2Int(x, y);
                levelDataSO.tiles.Add(tileData);

                InstantiateTile(tileData, x, y);
            }
        }
    }

    public void SaveGeneratedLevel()
    {
        ScriptableObjectSerializer<LevelDataSO>.SaveToFile(levelDataSO, savePath);
        Debug.Log($"Level Saved: {savePath}");
    }

    public void ClearLevel()
    {
        Debug.Log("Clearing level...");
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void LoadLevel()
    {
        ClearLevel();

        if (File.Exists(savePath))
        {
            Debug.Log("[LOAD LEVEL] LevelDataSO NULL: " + (levelDataSO == null));
            levelDataSO = ScriptableObjectSerializer<LevelDataSO>.LoadFromFile(savePath);
            Debug.Log($"Level Loaded: {savePath}");
            RecreateLoadedLevel();
        }
        else
        {
            Debug.Log("No saved level found. Generating a new level...");
            GenerateAndSaveLevel();
        }
    }

    public void RegenerateLevel()
    {
        Debug.Log("Regenerating level...");
        ClearLevel();
        GenerateLevel();
    }

    private void CenterCameraOnLevel()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            float aspectRatio = (float)Screen.width / Screen.height;

            if (aspectRatio > 1.0f)
            {
                mainCamera.orthographicSize = height / 2.0f;
            }
            else
            {
                mainCamera.orthographicSize = height / 2.0f / aspectRatio;
            }

            Vector3 centerPosition = new Vector3(
                ((width / 2.0f) - gridOffset) + levelDataSO.CellSize, 
                ((height / 2.0f) - gridOffset) + levelDataSO.CellSize, 
                CameraZPosition);
            mainCamera.transform.position = centerPosition;
        }
    }

    private Faker<LevelDataSO.TileData> CreateTileDataFaker()
    {
        return new Faker<LevelDataSO.TileData>()
            .RuleFor(td => td.hasObstacle, f => f.Random.Bool(ObstacleProbability))
            .RuleFor(td => td.levelTileType, f => f.PickRandom<LevelTileType>());
    }

    private void InstantiateTile(LevelDataSO.TileData tileData, int x, int y)
    {
        Vector3 position = new Vector3(x + gridOffset, y + gridOffset, 0);
        GameObject instance = tileData.hasObstacle ? obstaclePrefab : groundTilePrefab;
        GameObject tileInstance = Instantiate(instance, position, Quaternion.identity);
        tileInstance.transform.SetParent(transform);
        tileInstance.name = string.Format(TileNameFormat, x, y);
    }

    private void RecreateLoadedLevel()
    {
        foreach (LevelDataSO.TileData tileData in levelDataSO.tiles)
        {
            InstantiateTile(tileData, tileData.position.x, tileData.position.y);
        }
    }

    private void GenerateAndSaveLevel()
    {
        GenerateLevel();
        SaveGeneratedLevel();
    }
}
