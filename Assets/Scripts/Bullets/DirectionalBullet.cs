using UnityEngine;

public class DirectionalBullet : Projectile
{
    [Header("Bullet Settings")]
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _rayCastLength;
    [SerializeField] private float _lifeTime = 5f;

    private LayerMask _goalLayer;
    private Vector3 _direction;
    private Transform _transform;

    private float _lifeTimeTimer;
    private float _damage;

    private bool _canMove;

    public delegate void ReturnObjecteDelegate(DirectionalBullet bullet);
    public event ReturnObjecteDelegate OnReturnObject;

    private void OnEnable() {
        _canMove = false;
    }

    private void Update() {
        if (_direction != Vector3.zero) { 
            _canMove = true;
        }
        if (_canMove) {
            _transform.position += _direction * _projectileSpeed * Time.deltaTime;
           
            _lifeTimeTimer -= Time.deltaTime;
            if (_lifeTimeTimer < 0) {
                _canMove = false;
                OnReturnObject?.Invoke(this);
            }

            DetectCollision();
            Debug.DrawRay(_transform.position, _transform.forward * _rayCastLength, Color.blue);
        }        
    }

    private void DetectCollision() {
        RaycastHit hit;
        bool isDetectCollision = Physics.Raycast(_transform.position, _transform.forward, out hit, _rayCastLength, _goalLayer);
        if (!isDetectCollision) isDetectCollision = Physics.Raycast(_transform.position, -_transform.forward, out hit, _rayCastLength, _goalLayer);

        if (isDetectCollision) {
            Debug.Log("Collide With Enemy");
            StateMachine enemy = hit.transform.GetComponent<StateMachine>();
            enemy.TakeDamage(_damage);

            _canMove = false;
            OnReturnObject?.Invoke(this);
        } 
    }

    public void ThrowProjectile(Vector3 direction, LayerMask goalLayer, float damage) {
        if (_transform == null) {
            _transform = transform;
        }

        _direction = direction;
        _goalLayer = goalLayer;
        _damage = damage;
        _canMove = true;
        _lifeTimeTimer = _lifeTime;
    }
}
