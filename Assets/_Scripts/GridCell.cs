using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _offsetColor;

    public void Init(bool isOffset)
    {
        _spriteRenderer.color = isOffset ? _offsetColor : _baseColor;
    }
}
