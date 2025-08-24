using UnityEngine;

public class CellUIController: MonoBehaviour
{
    [SerializeField] private Cell _cell;
    [SerializeField] private CellView _cellView;
    private const int MAXGROWINDEX = 250;
    private const int STARTGROWINDEX = 10;
    private Vector3 _defaultScale;

    private void Start()
    {
        _cell.FighterChanged += OnFighterChanged;
        _defaultScale = _cellView.GetDefaultScale();
    }

    private void OnFighterChanged(int value)
    {
        _cellView.ShowText(value.ToString());
        UpdateSize(value);
    }

    private void UpdateSize(int value)
    {
        Vector3 newScale;
        if(value < MAXGROWINDEX)
        {
            if(value > STARTGROWINDEX)
            {
                int volume = 100 + value;
                newScale = _defaultScale* volume;
                _cellView.ShowScale(newScale);
            }
        }
    }
}
