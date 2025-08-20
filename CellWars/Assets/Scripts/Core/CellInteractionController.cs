using System.Collections.Generic;
using UnityEngine;

public class CellInteractionController : MonoBehaviour
{
    [SerializeField] private List<CellView> _cells;
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private CellView _selectedCell;

    public void Start()
    {
        _cells = new List<CellView>();
        _clickHandler.Click += CellClicked;
    }

    public void AddCell(CellView cell) 
    {
        _cells.Add(cell);
        Subscribe(cell);
    }

    private void Subscribe(CellView cell)
    {
        _cells.Add(cell);
    }

    private void CellClicked(CellView cellView)
    {
        if (cellView != null)
        {
            cellView.gameObject.TryGetComponent<Cell>(out Cell cell);
            if (cell.Owner == OwnerEnum.Player1)
                ClickOnPlayer(cellView);
            else ClickOnNPC(cellView);
        }
        else Unselect();
    }

    private void ClickOnPlayer(CellView cellView)
    {
        if (_selectedCell == null)
        {
            _selectedCell = cellView;
            return;
        }
        if (_selectedCell != null && _selectedCell != cellView)
        {
            Debug.Log("Send your fighters to another cell");
        }
        if (_selectedCell == cellView) 
        {
            Unselect();
        }
    }

    private void ClickOnNPC(CellView cellView) 
    {
        if(_selectedCell != null)
        {
            Debug.Log("Attacking " + cellView.name);
            Unselect();
        }
    }

    private void Unselect()
    {
        _selectedCell = null;
        Debug.Log("Unselect");
    }

}
