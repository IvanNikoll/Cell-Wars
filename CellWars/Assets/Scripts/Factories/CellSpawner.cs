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
        player.transform.position = _playerCellPos;
        player.InitializeCell(PlayerSettings.Fighters, PlayerSettings.Limit, PlayerSettings.Owner);
        CellBrain cellBrain = new CellBrain(player, _tickService, PlayerSettings.AddInterval);
    }

    private void InitializeNPC(Cell npc)
    {
        npc.transform.position = _NPCCellPos;
        npc.InitializeCell(NPCSettings.Fighters, NPCSettings.Limit, NPCSettings.Owner);
        CellBrain cellBrain = new CellBrain(npc, _tickService, NPCSettings.AddInterval);
    }
}
