using System.Collections.Generic;
using UnityEngine;

public class LevelContext : MonoBehaviour
{
    public static LevelContext Instance;
    [SerializeField] private LevelConfig _config;

    public LevelConfig Config {  get { return _config; } }
    public Vector3 PlayerPosition { get { return _config.PlayerPosition; } }
    public List<Vector3> EnemyPosition { get { return _config.EnemyPosition; } }
    public CellStats EnemyStats { get { return _config.EnemyStats; } }

    public CellStats GetEnemyStats()
    {
        return _config.EnemyStats;
    }

    public void SetLevelConfig(LevelConfig levelConfig)
    {
        _config = levelConfig;
    }

}
