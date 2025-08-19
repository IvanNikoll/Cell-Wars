using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    [SerializeField] private Cell _playerPrefab;
    [SerializeField] private Cell _NPCPrefab;
    [SerializeField] private Vector3 _playerCellPos;
    [SerializeField] private Vector3 _NPCCellPos;
    [SerializeField] private CellFactory _cellFactory;
    // add a player config and an enemy (enemies) config to initialize cell stats on start.

    public Cell GetCell(OwnerEnum owner)
    {
        if (owner == OwnerEnum.Player1)
        {
            Cell player = _cellFactory.GetCell(_playerPrefab);
            InitializePlayer(player);
            return player;
        }
        else
        {
            Cell NPC = _cellFactory.GetCell(_NPCPrefab);
            InitializeNPC(NPC);
            return NPC;
        }
    }

    private void InitializePlayer(Cell player)
    {
        //temporary solution
        int fighters = 10;
        int limit = 50;
        OwnerEnum owner = OwnerEnum.Player1;
        //
        player.transform.position = _playerCellPos;
        player.InitializeCell(fighters, limit, owner);
    }

    private void InitializeNPC(Cell npc)
    {
        //temporary solution
        int fighters = 5;
        int limit = 40;
        OwnerEnum owner = OwnerEnum.Playyer2;
        //
        npc.transform.position = _NPCCellPos;
        npc.InitializeCell(fighters, limit, owner);
    }
}
