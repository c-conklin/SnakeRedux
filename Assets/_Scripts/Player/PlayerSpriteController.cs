using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerSpriteController : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private PlayerDataSO _playerDataSO;
        
        private void Awake()
        {
            _playerDataSO = FindObjectOfType<PlayerGameManager>().runtimePlayerData;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _playerDataSO.OnDirectionChanged += ChangeSpriteDirection;
        }

        private void OnDisable()
        {
            _playerDataSO.OnDirectionChanged -= ChangeSpriteDirection;
        }

        private void ChangeSpriteDirection(Vector2 direction)
        {
            if (direction == Vector2.up)
            {
                _spriteRenderer.flipY = true;
            }
            else if (direction == Vector2.down)
            {
                _spriteRenderer.flipY = false;
            }
        }
    }
}
