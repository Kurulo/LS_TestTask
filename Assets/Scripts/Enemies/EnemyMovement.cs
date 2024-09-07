using UnityEngine;
using Zenject;

public class EnemyMovement
{
    private Transform _transform;
    private Rigidbody _rigidbody;
    private EnemySettings_SO _settings;
    private Transform _playerTransform;

    private Vector2 _randomPlayerOffset;

    public EnemyMovement(ContainerForEnemyComponents components) {
        _transform = components.Transform;
        _rigidbody = components.Rigidbody;
        _playerTransform = components.PlayerController.transform;
        _settings = components.Settings;

        _randomPlayerOffset = GetRandomOffset();
    }

    public void MoveToTarget() { 
        Vector3 directionToTarget = (_playerTransform.position - _transform.position).normalized;
        
        _rigidbody.MovePosition(_transform.position + directionToTarget * _settings.MoveSpeed * Time.deltaTime);    
    }

    public void RotaeToTarget() {   
        Vector3 playerPos = _playerTransform.position;

        if (GetDistanceToTarget(playerPos) > (_settings.AttackRange + 0.5f)) {
            playerPos.x += _randomPlayerOffset.x;
            playerPos.z += _randomPlayerOffset.y;
        }       

        Vector3 directionToTarget = playerPos - _transform.position;
        directionToTarget.y = 0f;


        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);

        _transform.rotation = Quaternion.Slerp(_transform.rotation, lookRotation, _settings.RotatingSpeed * Time.deltaTime);
    }

    private float GetDistanceToTarget(Vector3 targetPos) {
        return Vector3.Distance(_transform.position, targetPos);
    }

    private Vector2 GetRandomOffset() {
        float randomX = Random.Range(-2f, 2f);
        float randomY = Random.Range(-2f, 2f);

        return new Vector2(randomX, randomY);
    }
}
