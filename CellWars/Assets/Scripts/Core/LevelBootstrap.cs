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
    }

    private void InitiateEnemy()
    {
        Cell enemyCell = _cellSpawner.GetCell(OwnerEnum.Player2);
    }
}
