using UnityEngine;

/// <summary>
/// This class spawns cells on level start
/// </summary>
public class CellSpawner : MonoBehaviour
{
    [SerializeField] private CellInitializer _cellInitializer;

    [SerializeField] private Cell _playerPrefab;
    [SerializeField] private Cell _NPCPrefab;
    [SerializeField] private Vector3 _playerCellPos;
    [SerializeField] private Vector3 _NPCCellPos;
    [SerializeField] private CellFactory _cellFactory;

    public Cell GetCell(OwnerEnum owner)
    {
        if (owner == OwnerEnum.Player1)
        {
            Cell player = _cellFactory.GetCell(_playerPrefab);
            _cellInitializer.InitializeCell(player, owner);
            player.transform.position = _playerCellPos; // to be loaded from level settings
            return player;
        }
        else
        {
            Cell NPC = _cellFactory.GetCell(_NPCPrefab);
            _cellInitializer.InitializeCell(NPC,owner);
            NPC.transform.position = _NPCCellPos; // to be loaded from level settings
            return NPC;
        }
    }
}
