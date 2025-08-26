using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private IAttackable[] _cells;
    private List<IAttackable> _enemies;
    [SerializeField] private Cell _host;
    private CellBrain _cellBrain;

    public void Initialize(CellBrain brain)
    {
        _cellBrain = brain;
        _enemies = new List<IAttackable>();
        LocateCells();
    }

    private void LocateCells()//in future activate on event when all cells are spawned and the level starts
    {
        _cells = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IAttackable>().ToArray();
        if (_host.Owner != OwnerEnum.Player1)
        {
            foreach (IAttackable attackable in _cells)
            {
                OwnerEnum owner = attackable.CheckOwner();

                if (owner != _host.Owner)
                    _enemies.Add(attackable);
            }
            Debug.Log("Cells: " + _cells.Length);
            Debug.Log("Enemies:  " + _enemies.Count);
        }
    }
}
