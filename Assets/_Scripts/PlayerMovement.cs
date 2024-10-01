using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Player Movement")]
    [SerializeField] private float playerGridMovesPerSecond = 4;
    
    [Header("Player Position")]
    private int playerX = 0;
    private int playerY = 0;
    
    public GridManager gridManager;
    
    private Vector2 _direction;
    private float _timeSinceLastMove = 0;
    
    void Start()
    {
        transform.position = new Vector3(playerX, playerY, 0);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _direction = Vector2Int.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _direction = Vector2Int.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction = Vector2Int.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _direction = Vector2Int.right;
        }
    }
    
    private void MovePlayer()
    {
        playerX = (int)transform.position.x;
        playerY = (int)transform.position.y;
        
        if (playerX + _direction.x >= 0 && playerX + _direction.x <= gridManager.GameGrid.GridWidth)
        {
            playerX += (int)_direction.x;
        }
        
        if (playerY + _direction.y >= 0 && playerY + _direction.y <= gridManager.GameGrid.GridHeight)
        {
            playerY += (int)_direction.y;
        }
        
        transform.position = new Vector3(playerX, playerY, 0);
    }

    private void FixedUpdate()
    {
        _timeSinceLastMove += Time.fixedDeltaTime;
        
        // Move the player every 1 / playerGridMovesPerSecond seconds
        if (_timeSinceLastMove >= 1f / playerGridMovesPerSecond)
        {
            _timeSinceLastMove = 0;
            MovePlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
