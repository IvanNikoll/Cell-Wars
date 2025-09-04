using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

/// <summary>
/// This class is responcible for initiating cells on level start
/// </summary>
public class LevelBootstrap : MonoBehaviour
{
    [SerializeField] private CellSpawner _cellSpawner;
    [SerializeField] private CellInitializer _cellInitializer;
    [SerializeField] private TickService _tickService;
    [SerializeField] private LevelUIController _levelUIController;
    private List<Cell> _levelCells;

    private void Awake()
    {
        _levelCells = new List<Cell>();
        _cellInitializer.Configsloaded += OnConfigsLoaded;
    }

    private void OnConfigsLoaded()
    {
        InitiatePlayer();
        InitiateEnemy();
        _levelUIController.InitializeUI(_levelCells);
        GameStateController.Instance.ChangeState(new CountDownState(_tickService));
    }

    private void InitiatePlayer()
    {
        Cell playerCell = _cellSpawner.GetCell(OwnerEnum.Player1);
        _levelCells.Add(playerCell);
    }

    private void InitiateEnemy()
    {
        Cell enemyCell = _cellSpawner.GetCell(OwnerEnum.Player2);
        _levelCells.Add(enemyCell);
    }
}
