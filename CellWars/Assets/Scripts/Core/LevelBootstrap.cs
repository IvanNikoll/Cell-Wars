using UnityEngine;

public class LevelBootstrap : MonoBehaviour
{
    [SerializeField] private TickService _tickService;
    [SerializeField] private Cell _cellPrefab;
    private void Start()
    {
        Cell  playerCell = Instantiate(_cellPrefab, Vector3.zero, Quaternion.identity); 
        CellBrain cellBrain = new CellBrain(playerCell, _tickService);
    }
}
