using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image _healthAmounIMG;
    [SerializeField] private PlayerController _player;

    private Camera _camera;
    private Transform _transform;

    private void Start() {
        _player.HealthSystem.OnValueChangedEvent += UpdateHealthImage;

        _camera = Camera.main;
        _transform = transform;
    }

    private void Update() {
        Vector3 direction = _camera.transform.position - _transform.position;
        
        Quaternion rotation = Quaternion.LookRotation(direction * -1f);
        _transform.rotation = rotation;
    }

    private void UpdateHealthImage() {
        if (!_player.HealthSystem.IsDead() && _healthAmounIMG != null) {
            float procent = GetHealthChangedProcent();

            _healthAmounIMG.DOFillAmount(procent, 0.25f);
        }
    }

    private float GetHealthChangedProcent() {
        return _player.HealthSystem.CurrentHealth / _player.HealthSystem.MaxHealth;
    }
}
