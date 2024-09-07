using System;
using UnityEngine;

public class HealthSystem
{
    private float _maxHealth;
    private float _currentHealth;

    private bool _isDead;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public delegate void OnHealthChanged();
    public OnHealthChanged OnValueChangedEvent;

    public delegate void OnDead();
    public OnDead OnDeadEvent;

    public HealthSystem(float maxHealth) {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;

        _isDead = false;
    }

    public bool IsDead() {
        return _isDead;
    }

    public void DecreasHealth(float amount) {
        _currentHealth -= amount;

        OnValueChangedEvent?.Invoke();     

        if (_currentHealth <= 0) {
            _isDead = true;
            OnDeadEvent?.Invoke();
        }
    }

    public void IncreasHealth(float amount) {
        _currentHealth += amount;

        if (_currentHealth > _maxHealth) { 
            _currentHealth = _maxHealth;
        }

        OnValueChangedEvent?.Invoke();
    }

    public void ResetHealth() {
        _currentHealth = _maxHealth;
    }
}
