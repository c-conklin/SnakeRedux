using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player
{
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "Game/Player Data", order = 1)]
    public class PlayerDataSO : ScriptableObject
    {
        
        // --------------------------------------------------
        // EVENTS
        // --------------------------------------------------
        public event Action<Vector2> OnDirectionChanged;
        public event Action<Vector2Int> OnPositionChanged; 
        
        // --------------------------------------------------
        // PRIVATE FIELDS
        // --------------------------------------------------
        [Header("Player Movement")]
        [SerializeField] private Vector2Int _position;
        [SerializeField] private Vector2 _direction;
        
        [SerializeField] [Range(1f, 10f)]
        private float _playerGridMovesPerSecond = 4f;
        
        
        public Vector2 Direction
        {
            get => _direction;
            set
            {
                if (_direction != value)
                {
                    _direction = value;
                    OnDirectionChanged?.Invoke(_direction);
                }
            }
        }

        public Vector2Int Position
        {
            get => _position;
            set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPositionChanged?.Invoke(_position);
                }
            }
        }

        public float PlayerGridMovesPerSecond
        {
            get => _playerGridMovesPerSecond;
            set => _playerGridMovesPerSecond = value;
        }

        // Method to reset player data (optional)
        public void ResetPlayerData()
        {
            _position = new Vector2Int(2, 2);
            _direction = Vector2.zero;
            // Invoke events if needed
            OnPositionChanged?.Invoke(_position);
            OnDirectionChanged?.Invoke(_direction);
        }

        
    }
}
