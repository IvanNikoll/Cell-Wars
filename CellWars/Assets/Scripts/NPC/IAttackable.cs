using UnityEngine;

public interface IAttackable
{
    public OwnerEnum CheckOwner();
    public int CheckFighters();
    public Collider GetCollider();
    public void RemoveFighter();
    public void AddFighter();
}
