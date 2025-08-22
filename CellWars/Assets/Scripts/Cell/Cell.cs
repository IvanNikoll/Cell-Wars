using System;
using UnityEngine;

/// <summary>
/// This class holds information about cell and its stats
/// </summary>
public class Cell : MonoBehaviour, IFighterChanger
{
    public event Action<OwnerEnum> OnEngage;
    public event Action<Cell> Clicked;

    [SerializeField, Range(0,1000)] private int _fighters;
    [SerializeField] private int _limit;
    [SerializeField] private OwnerEnum _owner;

    public  int Fighters {  get { return _fighters; }}
    public int Limit { get { return _limit; }}
    public OwnerEnum Owner { get { return _owner; }}

    public void InitializeCell(int fighters, int limit, OwnerEnum owner)
    {
        _fighters = fighters;
        _limit = limit;
        _owner = owner;
    }

    public void AddFighter()
    {
        _fighters++;
    }

    public void RemoveFighter()
    {
        _fighters--;
    }

    public void ChangeOwner(OwnerEnum newOwner)
    {
        _owner = newOwner;
    }

    public int CheckFighters()
    {
        return Fighters;
    }

    public OwnerEnum CheckOwner()
    {
        return Owner;
    }
}