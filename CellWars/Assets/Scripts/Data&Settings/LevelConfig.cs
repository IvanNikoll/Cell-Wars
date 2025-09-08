using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LevelConfig", menuName = "Config/LevelConfig/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public Vector3 PlayerPosition { get { return _playerPosition; } }
    public List<Vector3> EnemyPosition {  get { return _enemyPosition; } }
    public CellStats EnemyStats { get { return _enemyStats; } }

    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private List<Vector3> _enemyPosition;
    [SerializeField] private CellStats _enemyStats;
}
