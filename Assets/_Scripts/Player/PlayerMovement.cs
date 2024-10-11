using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using _Scripts.Player;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    private Transform _playerTransform;
    private PlayerDataSO _playerDataSO;

    public LevelBuilder levelBuilder;
    private LevelDataSO _levelDataSO;
    
    // PRIVATE VARIABLES
    private float _timeSinceLastMove = 0;
    
    void Start()
    {
        _playerDataSO = FindObjectOfType<PlayerGameManager>().runtimePlayerData;
        _playerTransform = transform;
        _levelDataSO = levelBuilder.levelDataSO;

        // Initialize player position from PlayerDataSO
        _playerTransform.position = new Vector3(_playerDataSO.Position.x, _playerDataSO.Position.y, 0);

        // Subscribe to PlayerDataSO events
        _playerDataSO.OnPositionChanged += UpdatePlayerPosition;
    }

    void OnDestroy()
    {
        // Unsubscribe from events to prevent memory leaks
        _playerDataSO.OnPositionChanged -= UpdatePlayerPosition;
    }

    private void Update()
    {
        SetDirection();
    }

    private void FixedUpdate()
    {
        _timeSinceLastMove += Time.fixedDeltaTime;
        if (_timeSinceLastMove >= 1f / _playerDataSO.PlayerGridMovesPerSecond)
        {
            _timeSinceLastMove = 0;
            MovePlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player Triggered:" + other.gameObject.name);
        if (other.gameObject.CompareTag("Food"))
        {
            Debug.Log("Player Ate Food");
            GrowPlayer();
        }
    }

    private void GrowPlayer()
    {
        // Handle player growth logic
    }

    private void MovePlayer()
    {
        Vector2Int currentPosition = _playerDataSO.Position;

        // Update position based on direction, ensuring within level bounds
        int newX = currentPosition.x;
        int newY = currentPosition.y;

        if (newX + _playerDataSO.Direction.x >= 1 && newX + _playerDataSO.Direction.x <= _levelDataSO.width)
        {
            newX += (int)_playerDataSO.Direction.x;
        }

        if (newY + _playerDataSO.Direction.y >= 1 && newY + _playerDataSO.Direction.y <= _levelDataSO.height)
        {
            newY += (int)_playerDataSO.Direction.y;
        }

        // Update the position in PlayerDataSO
        _playerDataSO.Position = new Vector2Int(newX, newY);
    }

    private void SetDirection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _playerDataSO.Direction = Vector2Int.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _playerDataSO.Direction = Vector2Int.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _playerDataSO.Direction = Vector2Int.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _playerDataSO.Direction = Vector2Int.right;
        }
    }

    private void UpdatePlayerPosition(Vector2Int newPosition)
    {
        // Update the transform position when PlayerDataSO position changes
        _playerTransform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }

    public void ResetPlayerPosition()
    {
        _playerDataSO.ResetPlayerData();
    }
}
