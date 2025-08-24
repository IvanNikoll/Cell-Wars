using TMPro;
using UnityEngine;

/// <summary>
/// This class holds cell UI and visuals
/// </summary>
public class CellView : MonoBehaviour, IViewUpdater
{
    [SerializeField] private Color _cellColor;
    [SerializeField] private Sprite _cellSprite;
    [SerializeField] private Transform _cellTransform;
    [SerializeField] private TextMeshPro _cellText;
    private Vector3 _defaultScale;

    public Color CellColor { get { return _cellColor; } set { _cellColor = value; } }
    public Sprite CellSprite { get { return _cellSprite; } set { _cellSprite = value; } }

    private void Start()
    {
        _defaultScale = transform.localScale;
    }

    public void InitializeView(Color color, Sprite sprite, Transform transform, TextMeshPro cellText)
    {
        _cellColor = color;
        _cellSprite = sprite;
        _cellTransform = transform;
        _cellText = cellText;
        _defaultScale = _cellTransform.localScale;
    }

    public void ShowText(string text)
    {
        if (_cellText != null) 
            _cellText.SetText(text);
    }

    public void ShowScale(Vector3 scale)
    {
        if (_cellTransform != null)
        {
            _cellTransform.localScale = scale;
        }
    }

    public Vector3 GetDefaultScale()
    {
        return _defaultScale;
    }

    public void UpdateVisual()
    {
        //pass view prefab here and assign it to cell
    }

    public void ShowScale(System.Numerics.Vector3 scale)
    {
        throw new System.NotImplementedException();
    }
}
