using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private IAttackable[] _cells;
    private List<IAttackable> _enemies;
    [SerializeField] private Cell _host;
    [SerializeField] private CellInteractionController _interactionController;
    private CellBrain _cellBrain;

    public void Initialize(CellBrain brain, CellInteractionController interactionController)
    {
        _cellBrain = brain;
        _interactionController = interactionController;
        _enemies = new List<IAttackable>();
        LocateCells();
        StartCoroutine(AIUpdateCoroutine());
    }

    private void LocateCells()
    {
        _cells = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
            .OfType<IAttackable>()
            .ToArray();
        Debug.Log("Cells found: " + _cells.Length);
    }

    private IEnumerator AIUpdateCoroutine()
    {
        yield return new WaitForSecondsRealtime(8f);
        while (true)
        {
            UpdateEnemies();
            TryAttack();
            yield return new WaitForSecondsRealtime(8f);
        }
    }

    private void UpdateEnemies()
    {
        _enemies.Clear();
        if (_host.Owner != OwnerEnum.Player1)
        {
            foreach (IAttackable attackable in _cells)
            {
                OwnerEnum owner = attackable.CheckOwner();
                if (owner != _host.Owner)
                    _enemies.Add(attackable);
            }
        }
        Debug.Log("Enemies updated: " + _enemies.Count);
    }

    private void TryAttack()
    {
        if (_enemies.Count == 0)
            return;

        int myFighters = _host.Fighters;
        int weakestEnemyFighters = int.MaxValue;
        IAttackable targetEnemy = null;
        foreach (var enemy in _enemies)
        {
            int enemyFighters = enemy.CheckFighters();

            if (enemyFighters < weakestEnemyFighters)
            {
                weakestEnemyFighters = enemyFighters;
                targetEnemy = enemy;
            }
        }
        if (targetEnemy != null && weakestEnemyFighters <= myFighters * 1.5f)
        {
            Attack(targetEnemy);
        }
    }

    private void Attack(IAttackable target)
    {
        if (this.gameObject.TryGetComponent<IAttackable>(out IAttackable host))
        {
            _interactionController.SendCells(host, target, _host.Fighters / 2);
        }
    }
}