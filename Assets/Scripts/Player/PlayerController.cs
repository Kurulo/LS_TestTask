using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("Movement Settings")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotateSpeed;

    [Header("Health Settings")]
    [SerializeField] private float _health;
    
    private HealthSystem _healthSystem;
    public HealthSystem HealthSystem => _healthSystem;

    private Vector3 _inputDirection;
    private Transform _transform;
    private Animator _animator;

    private PlayerInputHandler _inputHandler;
    
    private void Start() {
        _inputHandler = new PlayerInputHandler();
        _transform = transform;

        _healthSystem = new HealthSystem(_health);
        _healthSystem.OnDeadEvent += Death;
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        UpdateInputDirection();

        if (_inputDirection != Vector3.zero) {
            Movement();
            Rotation();
        } else {
            _animator.SetBool("IsMoving", false);
        }
    }

    private void Movement() {
        _animator.SetBool("IsMoving", true);
        _transform.position += _inputDirection * _movementSpeed * Time.deltaTime;
    }

    private void Rotation() {
        Quaternion lookRotation = Quaternion.LookRotation(_inputDirection);

        _transform.rotation = Quaternion.Slerp(_transform.rotation, lookRotation, _rotateSpeed * Time.deltaTime);
    }

    private void UpdateInputDirection() {
        Vector2 input = _inputHandler.GetKeyboardInput();
        _inputDirection = new Vector3(input.x, 0f, input.y).normalized;
    }

    public void TakeDamage(float amount) {
        _healthSystem.DecreasHealth(amount);
    }

    public void HealByAmount(float amount) {
        _healthSystem.IncreasHealth(amount);
    }

    private void Death() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy() {
        DOTween.KillAll();
    }
}
