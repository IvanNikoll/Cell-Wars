public interface IFighterChanger
{
    public int CheckFighters();
    public OwnerEnum CheckOwner();
    public void AddFighter();
    public void RemoveFighter();
    public void ChangeOwner(OwnerEnum newOwner);
}
