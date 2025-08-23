using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls interaction with cells
/// </summary>
public class CellInteractionController : MonoBehaviour
{
    [SerializeField] private FighterController _fighterController;
    [SerializeField] private List<CellView> _cells;
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private CellView _selectedCell;
    private Coroutine _spawningCoroutine;
    private float _nextTimeToEmit = 0.5f;

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
            SendCells(cellView);
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
            SendCells(cellView);
        }
    }

    private void Unselect()
    {
        _selectedCell = null;
    }

    private void SendCells(CellView target)
    {
        _selectedCell.TryGetComponent<IFighterChanger>(out IFighterChanger cell);
        OwnerEnum owner = cell.CheckOwner();
        int fighters = cell.CheckFighters();
        int fightersToSpawn = Mathf.RoundToInt(fighters / 2);
        _spawningCoroutine = StartCoroutine(FighterSpawningCoroutine(cell, owner, target, fightersToSpawn));
    }

    private IEnumerator FighterSpawningCoroutine(IFighterChanger fighterChanger, OwnerEnum owner, CellView target, int fightersToSpawn)
    {
        for (int i = 0; i < fightersToSpawn; i++)
        {
            _fighterController.EmitFighter(owner, _selectedCell.transform, target.transform);
            fighterChanger.RemoveFighter();
            yield return new WaitForSecondsRealtime(_nextTimeToEmit);
        }
        _spawningCoroutine = null;
        Unselect();
    }
}
