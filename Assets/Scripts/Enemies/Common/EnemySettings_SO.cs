using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/StandartEnemy", fileName = "New Enemy")]
public class EnemySettings_SO : ScriptableObject
{
    [Header("Health")]
    [SerializeField] private float _health;

    [Header("Move Settings")]
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _rotatingSpeed = 20f;
    [SerializeField] private float _stopingDistance = 0.5f;

    [Header("Attack Settings")]
    [SerializeField] private float _attackInterval;
    [SerializeField] private float _damage;

    [Header("Ranges")]
    [SerializeField] private float _chasingRange;
    [SerializeField] private float _attackRange;

    // Public
    public float Health => _health;
    public float MoveSpeed => _moveSpeed;
    public float RotatingSpeed => _rotatingSpeed;
    public float StopingDistance => _stopingDistance;
    public float AttackRange => _attackRange; 
    public float ChasingRange => _chasingRange;
    public float AttackInterval => _attackInterval;
    public float Damage => _damage;
    
}
