using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    [SerializeField] private Cell _playerPrefab;
    [SerializeField] private Cell _NPCPrefab;
    [SerializeField] private Vector3 _playerCellPos;
    [SerializeField] private Vector3 _NPCCellPos;
    [SerializeField] private CellFactory _cellFactory;
    [SerializeField] private PlayerSettings PlayerSettings; // change to a congfig file or class later
    [SerializeField] private PlayerSettings NPCSettings; // create a class responsible for loading level configs and pass number and stats of enemies here.
    [SerializeField] private TickService _tickService;

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
        int fighters = PlayerSettings.Fighters;
        int limit = PlayerSettings.Limit;
        OwnerEnum owner = PlayerSettings.Owner;
        player.transform.position = _playerCellPos;
        player.InitializeCell(fighters, limit, owner);
        CellBrain cellBrain = new CellBrain(player, _tickService);
    }

    private void InitializeNPC(Cell npc)
    {
        int fighters = NPCSettings.Fighters;
        int limit = NPCSettings.Limit;
        OwnerEnum owner = NPCSettings.Owner;
        npc.transform.position = _NPCCellPos;
        npc.InitializeCell(fighters, limit, owner);
        CellBrain cellBrain = new CellBrain(npc, _tickService);
    }
}
