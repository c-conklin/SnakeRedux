using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [SerializeField] private GameObject player;
    TextMeshProUGUI _textMesh;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        _textMesh.text = $"Player Position: {player.transform.position}";
    } 
}
