using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Player Movement")]
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float speedMultiplier = 2.0f;
    
    private Vector2 direction;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2Int.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2Int.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2Int.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2Int.right;
        }

        transform.Translate(direction * (speed * speedMultiplier) * Time.deltaTime);
    }
}
