using UnityEngine;

/// <summary>
/// This is a test object for holding player stats. to be swapped to a config file later
/// </summary>
[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Settings/StartSettings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] private int _fighters;
    [SerializeField] private int _limit;
    [SerializeField] private OwnerEnum _owner;
    [SerializeField] private float _addInterval;

    public int Fighters { get { return _fighters; } }
    public int Limit { get { return _limit; } }
    public OwnerEnum Owner { get { return _owner; } }
    public float AddInterval { get { return _addInterval; } }
}