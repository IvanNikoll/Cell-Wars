using UnityEngine;

public class LevelBootstrap : MonoBehaviour
{
    [SerializeField] private CellSpawner _cellSpawner;
    private void Start()
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
