using UnityEngine;
using UnityEngine.Pool;

public class FighterController : MonoBehaviour
{
    [SerializeField] private Projectile _fighterPrefab;
    [SerializeField] private Transform _emitionPosition;

    [SerializeField] private IObjectPool<Projectile> _objectPool;
    [SerializeField] private bool _collectionCheck = true;
    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _maxSize;
    private bool _canEmit = true;
    private float _timer;
    private float _nextTimeToEmit = 0.2f;

    private void Awake()
    {
        _objectPool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyObject, true, 100, 3000);
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer > _nextTimeToEmit)
        {
            _canEmit = true;
            _timer = 0f;
        }
    }

    public void EmitFighter(OwnerEnum owner,Transform hostTransform, Transform targetTransform)
    {
        Projectile fighter = _objectPool.Get();
        fighter.transform.SetPositionAndRotation(hostTransform.position, hostTransform.rotation);
        fighter.Initialize(owner, targetTransform.position);
        _canEmit = false;
    }

    private Projectile CreateProjectile()
    {
        Projectile projectileInstance = Instantiate(_fighterPrefab);
        projectileInstance.ObjectPool = _objectPool;
        return projectileInstance;
    }

    private void OnGetFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }

    private void OnDestroyObject(Projectile projectile)
    {
        GameObject.Destroy(projectile.gameObject);
    }
}
