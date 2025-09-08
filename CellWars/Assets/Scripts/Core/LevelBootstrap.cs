using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// This class is responcible for initiating cells on level start
/// </summary>
public class LevelBootstrap : MonoBehaviour
{
    [Inject] private CellSpawner _cellSpawner;
    [Inject] private LevelConfigProvider _configProvider;

    [SerializeField] private CellInitializer _cellInitializer;
    [SerializeField] private TickService _tickService;
    [SerializeField] private LevelUIController _levelUIController;
    private List<Cell> _levelCells;

    private void Awake()
    {
        _levelCells = new List<Cell>();
        _cellInitializer.Configsloaded += OnConfigsLoaded;
        _configProvider.GetLevelConfig(LevelEnum.Level2);
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
