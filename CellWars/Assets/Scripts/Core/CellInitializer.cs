using System;
using UnityEngine;

public class CellInitializer : MonoBehaviour
{
    public event Action Configsloaded;
    [SerializeField] private CellStats _playerStats;
    [SerializeField] private CellStats _NPCStats;
    [SerializeField] private CellConfig _playerConfig;
    [SerializeField] private CellConfig _NPCConfig;
    [SerializeField] private TickService _tickService;

    private void Start()
    {
        LoadConfigs();
    }

    private void LoadConfigs()
    {
        _playerConfig = new CellConfig(_playerStats.Fighters, _playerStats.Limit, _playerStats.Owner, _playerStats.AddInterval);
        _NPCConfig = new CellConfig(_NPCStats.Fighters, _NPCStats.Limit, _NPCStats.Owner, _NPCStats.AddInterval);
        Configsloaded?.Invoke();
    }

    public void InitializeCell(Cell cell, OwnerEnum owner)
    {
        CellConfig config = GetConfig(owner);
        if (config != null)
        {
            cell.InitializeCell(config.Fighters, config.Limit, config.Owner);
            CellBrain cellBrain = new CellBrain(cell, _tickService, config.AddInterval);
            cell.gameObject.TryGetComponent<NPCController>(out NPCController npcController);
            if (npcController != null) npcController.Initialize(cellBrain);
        }
        else throw new ArgumentNullException(nameof(config));
    }

    public CellConfig GetConfig(OwnerEnum owner)
    {
        switch (owner)
        { 
            case OwnerEnum.Player1:
                return _playerConfig;
            case OwnerEnum.Player2:
                return _NPCConfig;
            default:
                return null;
        } 
    }
}
