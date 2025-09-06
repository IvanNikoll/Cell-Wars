using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// This cllass holds and navigates fighters.
/// </summary>
public class Projectile : MonoBehaviour
{
    public Color Color {  get; private set; }
    [SerializeField] private MeshRenderer _meshRenderer;
    private IAttackable _host;
    private IAttackable _target;
    private IObjectPool<Projectile> _objectPool;
    public IObjectPool<Projectile> ObjectPool { set { _objectPool = value; } }
    public OwnerEnum Owner { get { return _owner; } }
    public bool IsActive {  get { return _isActive; } }
    private Collider _hostCollider;
    private Collider _targetCollider;  
    private bool _isActive;
    private float _speed = 0.3f; // to be set in Initialize later;
    private OwnerEnum _owner;
    public void Initialize(IAttackable host, IAttackable target, Color color)
    {
        _host = host;
        _target = target;
        _owner = host.CheckOwner();
        _hostCollider = host.GetCollider();
        _targetCollider = target.GetCollider();
        _isActive = true;
        transform.LookAt(_targetCollider.transform);

        Material material = new Material(_meshRenderer.material);
        material.color = color;
        material.SetFloat("_Metallic", 1f);
        _meshRenderer.material = material;
    }

    private void FixedUpdate()
    {
        if (_isActive && _target != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                _targetCollider.transform.position,
                _speed * Time.fixedDeltaTime
            );
        }
    }

    public void Deactivate()
    {
        _host = null;
        _target = null;
        _isActive = false;
        _objectPool.Release(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _hostCollider)
            return;
        if(other.TryGetComponent<Projectile>(out Projectile projectile))
        {
            if(projectile != null)
            {
                if(projectile.Owner != Owner && projectile.IsActive)
                {
                    projectile.Deactivate();
                    Deactivate();
                }
            }
        }
        if (_target != null && other == _targetCollider)
        {
            var incomingOwner = _target.CheckOwner();

            if (incomingOwner != _host.CheckOwner())
                _target.RemoveFighter();
            else
                _target.AddFighter();
            Deactivate();
        }
    }
}