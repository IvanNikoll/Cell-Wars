using System;
using TMPro;
using UnityEngine;

/// <summary>
/// This class holds cell UI and visuals
/// </summary>
public class CellView : MonoBehaviour, IViewUpdater
{
    [SerializeField] private Cell _cell;
    private CellInitializer _cellInitializer;
    [SerializeField] private Color _cellColor;
    [SerializeField] private Sprite _cellSprite;
    [SerializeField] private Transform _cellTransform;
    [SerializeField] private TextMeshPro _cellText;
    [SerializeField] private MeshRenderer _innerCellMeshRenderer;
    [SerializeField] private MeshRenderer _outerCellMeshRenderer;
    private Vector3 _defaultScale;

    public Color CellColor { get { return _cellColor; } set { _cellColor = value; } }
    public Sprite CellSprite { get { return _cellSprite; } set { _cellSprite = value; } }

    private void Start()
    {
        _defaultScale = transform.localScale;
        _cell.OwnerChanged += UpdateColor;
    }

    private void UpdateColor(OwnerEnum owner)
    {
        Color color;
        switch (owner)
        {
            case OwnerEnum.Player1:
                color = _cellInitializer.PlayerConfig.Color;
                break;
            case OwnerEnum.Player2:
                color = _cellInitializer.NPCConfig.Color;
                break;
            default:
                throw new NotImplementedException();
        }
        UpdateVisual(color);
    }

    public void InitializeView(Color color, CellInitializer cellInitializer)
    {
        _cellInitializer = cellInitializer;
        _cellColor = color;
        _defaultScale = _cellTransform.localScale;
        UpdateVisual(color);
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

    public void UpdateVisual(Color color)
    {
        Material material = new Material(_innerCellMeshRenderer.material);
        material.color = color;
        material.SetFloat("_Metallic", 1f);
        _innerCellMeshRenderer.material = material;
        _outerCellMeshRenderer.material = material;
    }

    public void ShowScale(System.Numerics.Vector3 scale)
    {
        throw new System.NotImplementedException();
    }
}
