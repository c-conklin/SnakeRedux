using System;
using _Scripts;
using _Scripts.Shared;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameManager _gameManager;

    [SerializeField]
    private LevelBuilder _levelBuilder;
    private LevelDataSO _levelDataSO => _levelBuilder.levelDataSO;
    
    public static event Action OnFoodEaten;
    
    
    void Start()
    {
        RandomizedFoodPosition();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RandomizedFoodPosition();
            OnFoodEaten?.Invoke();
        }
    }
    
    private void RandomizedFoodPosition()
    {
        while (true)
        {
            transform.position = new Vector3(
                UnityEngine.Random.Range(_levelDataSO.minX, _levelDataSO.width),
                UnityEngine.Random.Range(_levelDataSO.minY, _levelDataSO.height),
                0);

            // Check if the food is spawning on the player
            if (transform.position == _gameManager.playerMovement.transform.position)
            {
                continue;
            }

            break;
        }
    }
}
