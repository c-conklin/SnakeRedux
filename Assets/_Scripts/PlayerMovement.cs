using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 1.0f;
    
    private Vector2 direction;
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) direction = Vector2Int.up;
        
        if (Input.GetKey(KeyCode.S)) direction = Vector2Int.down;
        
        if (Input.GetKey(KeyCode.A)) direction = Vector2Int.left;
        
        if (Input.GetKey(KeyCode.D)) direction = Vector2Int.right;

        // make players transform translate to rounded int values
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }
}
