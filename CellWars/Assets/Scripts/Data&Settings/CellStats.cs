using UnityEngine;

[CreateAssetMenu(fileName = "CellStats", menuName = "Config/Stats/CellStats")]
public class CellStats : ScriptableObject
{
    [SerializeField, Range(0,100)] private int _fighters;
    [SerializeField, Range(0,500)] private int _limit;
    [SerializeField] private OwnerEnum _owner;
    [SerializeField, Range(0.2f,3)] private float _addInterval;

    public int Fighters { get { return _fighters; } }
    public int Limit { get { return _limit; } }
    public OwnerEnum Owner { get { return _owner; } }
    public float AddInterval { get { return _addInterval; } }
}
