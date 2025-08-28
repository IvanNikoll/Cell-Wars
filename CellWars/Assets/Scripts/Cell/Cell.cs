using System;
using UnityEngine;

/// <summary>
/// This class holds information about cell and its stats
/// </summary>
public class Cell : MonoBehaviour, IFighterChanger, IAttackable
{
    public event Action<OwnerEnum> OwnerChanged;
    public event Action<Cell> Clicked;
    public event Action<int> FighterChanged;

    [SerializeField, Range(0, 1000)] private int _fighters;
    [SerializeField] private int _limit;
    [SerializeField] private OwnerEnum _owner;
    public  int Fighters {  get { return _fighters; }}
    public int Limit { get { return _limit; }}
    public OwnerEnum Owner { get { return _owner; }}
    private Collider _collider;

    public void InitializeCell(int fighters, int limit, OwnerEnum owner)
    {
        _fighters = fighters;
        _limit = limit;
        _owner = owner;
        TryGetComponent<Collider>(out _collider);
    }

    public void AddFighter()
    {
        _fighters++;
        FighterChanged?.Invoke(_fighters);
    }

    public void RemoveFighter()
    {
        _fighters--;
        FighterChanged?.Invoke(_fighters);
    }

    public void ChangeOwner(OwnerEnum newOwner)
    {
        _owner = newOwner;
        OwnerChanged?.Invoke(newOwner);
    }

    public int CheckFighters()
    {
        return Fighters;
    }

    public OwnerEnum CheckOwner()
    {
        return Owner;
    }

    public Collider GetCollider()
    {
        return _collider;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<Projectile>(out Projectile fighter);
        if (fighter != null)
        {
            if (_fighters == 0)
                ChangeOwner(fighter.Owner);
        }
    }
}