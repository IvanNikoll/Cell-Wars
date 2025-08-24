using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// This cllass holds and navigates fighters.
/// </summary>
public class Projectile : MonoBehaviour
{
    private IObjectPool<Projectile> _objectPool;
    public IObjectPool<Projectile> ObjectPool { set { _objectPool = value; } }
    public OwnerEnum Owner { get { return _owner; } }

    [SerializeField] private OwnerEnum _owner;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private bool _isActive;

    private float _speed = 0.3f; // to be set in Initialize later;

    public void Initialize(OwnerEnum owner, Vector3 target)
    {
        _owner = owner;
        _targetPosition = target;
        _isActive = true;
    }

    public void FixedUpdate()
    {
        if (_isActive) 
        {
             transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.fixedDeltaTime);
        }
    }

    public void Deactivate()
    {
        _owner = OwnerEnum.Player1;
        _targetPosition = Vector3.zero;
        _isActive = false;
        _objectPool.Release(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<IFighterChanger>(out IFighterChanger cell);
        OwnerEnum incomingOwner = cell.CheckOwner();
        bool isTarget;
        if(other.gameObject.transform.position == _targetPosition)
            isTarget = true;
        else isTarget = false;
        if (isTarget && cell != null && incomingOwner != _owner)
        {
            cell.RemoveFighter();
            Deactivate();
        }
        if (isTarget && cell != null && incomingOwner == _owner)
        {
            cell.AddFighter();
            Deactivate();
        }
    }
}