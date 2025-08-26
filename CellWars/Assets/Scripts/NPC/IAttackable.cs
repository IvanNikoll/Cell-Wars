using UnityEngine;

public interface IAttackable
{
    public OwnerEnum CheckOwner();
    public int CheckFighters();
    public Vector3 CheckPosition();

}
