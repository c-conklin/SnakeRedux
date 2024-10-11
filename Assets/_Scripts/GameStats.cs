using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using _Scripts;
using TMPro;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;
    [SerializeField] private GameObject player;
    [SerializeField] private GameScore _gameScore;
    
    const string _gameScoreText = "Score: ";
    const string _playerPositionText = "Player Position: ";
    
    void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        _textMesh.text = string.Empty;
    }
    
    void Update()
    {
        UpdateStats();
    }
    
    public void UpdateStats()
    {
        var sb = new StringBuilder();
        sb.Append(_gameScoreText);
        sb.Append(_gameScore?.Score ?? 0);
        sb.Append("\n");
        sb.Append(_playerPositionText);
        sb.Append(player?.transform.position ?? Vector3.zero);
        if (_textMesh) _textMesh.text = sb.ToString();
    }
    
    
}
