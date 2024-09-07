using UnityEngine;

public class SphereCastWeapon : Weapon
{
    [SerializeField] private float _attackRadius = 10f;

    [Header("Projectile Settings")]
    [SerializeField] private DirectionalBullet _directionalBullet;

    [Header("Pool Settings")]
    [SerializeField] private PoolOfObjects<DirectionalBullet> _pool;
    [SerializeField] private bool _autoExpand;

    private float _attackTimer = 0f;

    private Vector3 _directionToTarget = Vector3.zero;
    private Transform _transform;

    private void Start() {
        _pool.PoolSetup(_directionalBullet, _directionalBullet.gameObject, 200);
        _pool.FillPool(5);

        _transform = transform;
        _attackTimer = _attackInterval;
        _isReadyToUse = false;
    }

    private void Update() {
        if (_attackTimer > 0) {
            _attackTimer -= Time.deltaTime;
        }

        if (CheckIfHasNearestEnemy() && _attackTimer <= 0) {
            _isReadyToUse = true;
        }
    }

    public override void UseWeapon() {
        StateMachine enemy = _owner.GetNearestEnemyInRadius(_attackRadius);
        _directionToTarget = GetDirectionToTarget(enemy.transform.position);

        DirectionalBullet bullet = SetupBullet(_pool.TryGetObjectFromPool() as DirectionalBullet);
        bullet.ThrowProjectile(_directionToTarget, _owner.EnemyLayer, _damage);
        bullet.OnReturnObject += ReturnBulletToPool;

        _isReadyToUse = false;
        _attackTimer = _attackInterval;  
    }

    private void ReturnBulletToPool(DirectionalBullet bullet) {
        bullet.gameObject.SetActive(false);
        _pool.AddToPool(bullet);
    }

    private DirectionalBullet SetupBullet(DirectionalBullet setuptedBullet) {
        var bullet = setuptedBullet;

        bullet.gameObject.SetActive(true);

        Vector3 spawnPosition = _transform.position + _directionToTarget.normalized;
        Quaternion rotation = Quaternion.LookRotation(_directionToTarget);

        bullet.transform.position = spawnPosition;
        bullet.transform.rotation = rotation;

        return bullet;
    }

    private Vector3 GetDirectionToTarget(Vector3 targetPos) {
        Vector3 direction = targetPos - _transform.position;
        direction.y = 0f;
        return direction;
    }

    private bool CheckIfHasNearestEnemy() {
        StateMachine enemy = _owner.GetNearestEnemyInRadius(_attackRadius);
        return enemy != null && !enemy.Componets.HealthSytem.IsDead();
    }
}
