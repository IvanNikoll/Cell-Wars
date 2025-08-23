using System;
using UnityEngine;

/// <summary>
/// This class is responcible for initiating cells on level start
/// </summary>
public class LevelBootstrap : MonoBehaviour
{
    [SerializeField] private CellSpawner _cellSpawner;
    [SerializeField] private CellInitializer _cellInitializer;

    private void Awake()
    {
        _cellInitializer.Configsloaded += OnConfigsLoaded;
    }

    private void OnConfigsLoaded()
    {
        InitiatePlayer();
        InitiateEnemy();
    }

    private void InitiatePlayer()
    {
        Cell playerCell = _cellSpawner.GetCell(OwnerEnum.Player1);
        playerCell.TryGetComponent<CellView>(out CellView playerView);

    }

    private void InitiateEnemy()
    {
        Cell enemyCell = _cellSpawner.GetCell(OwnerEnum.Player2);
        enemyCell.TryGetComponent<CellView> (out CellView enemyView);
    }
}
