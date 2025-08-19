using UnityEngine;

public class LevelBootstrap : MonoBehaviour
{
    [SerializeField] private TickService _tickService;
    [SerializeField] private CellSpawner _cellSpawner;
    private void Start()
    {
        InitiatePlayer();
        InitiateEnemy();
    }

    private void InitiatePlayer()
    {
        Cell playerCell = _cellSpawner.GetCell(OwnerEnum.Player1);
        CellBrain cellBrain = new CellBrain(playerCell, _tickService);
    }

    private void InitiateEnemy()
    {
        Cell enemyCell = _cellSpawner.GetCell(OwnerEnum.Playyer2);
        CellBrain cellBrain = new CellBrain(enemyCell, _tickService);
    }
}
