using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIController : MonoBehaviour
{
    public event Action<OwnerEnum> FightersDestroyed;
    [SerializeField] LevelUIView _levelView;
    [SerializeField] MultySlider _slider;
    [SerializeField] private int _playerFighters;
    [SerializeField] private int _npcFighters;
    [SerializeField] private int _maxFighters;
    [SerializeField] private List<Cell> _spawnedCells;
    [SerializeField] private List<Cell> _playerCells;
    [SerializeField] private List<Cell> _npcCells;
    private const float COUNTDOWNINTERVAL = 0.3f;
    private float _t;
    
    private void Awake()
    {
        _levelView = GetComponent<LevelUIView>();
        _spawnedCells = new List<Cell>();
        _playerCells = new List<Cell>();
        _npcCells = new List<Cell>();
    }

    private void FixedUpdate()
    {
        Tick();
    }

    private void UpdateFighters()
    {
        _playerFighters = 0;
        _npcFighters = 0;
        {
            foreach(Cell cell in _playerCells)
            {
                int fighters = cell.Fighters;
                _playerFighters += fighters;
            }
            foreach(Cell cell in _npcCells)
            {
                int fighters = cell.Fighters;
                _npcFighters += fighters;
            }
            _levelView.UpdateText(_playerFighters, _npcFighters);

        }
    }

    public void InitializeUI(List<Cell> spawnedCells)
    {
        _spawnedCells = spawnedCells;
        foreach (var cell in _spawnedCells)
        {
            cell.OwnerChanged += UpdateLists;
        }

        UpdateLists(OwnerEnum.Player1);
    }

    private void UpdateLists(OwnerEnum owner)
    {
        CheckDestroyed();
        _playerCells.Clear();
        _npcCells.Clear();
        foreach (var cell in _spawnedCells)
        {
            switch (cell.Owner)
            {
                case OwnerEnum.Player1:
                    _playerCells.Add(cell);
                    break;
                case OwnerEnum.Player2:
                    _npcCells.Add(cell);
                    break;
            }
        }
    }

    private void Tick()
    {
        if (GameStateController.Instance.CanUpdateUI)
        {
            _t += Time.deltaTime;
            if (_t > COUNTDOWNINTERVAL)
            {
                UpdateFighters();
                _slider.Show(_playerFighters, _npcFighters, 0);
                _t = 0;
            }
        }
    }

    private void CheckDestroyed()
    {
        if (!(GameStateController.Instance.CurrentState is StartState))
            return;
        if (_playerFighters ==0)
            FightersDestroyed?.Invoke(OwnerEnum.Player1);
        if(_npcFighters ==0)
            FightersDestroyed?.Invoke(OwnerEnum.Player2);
    }
}