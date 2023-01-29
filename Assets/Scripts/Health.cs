using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;

    private float _currentHealth;

    public event UnityAction<float> HealthChanged;

    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal()
    {
        _currentHealth += _heal;

        if (_currentHealth <= _maxHealth)
        {
            HealthChanged?.Invoke(_currentHealth);
        }
        else
        {
            _currentHealth = _maxHealth;
            HealthChanged?.Invoke(_currentHealth);
        }    
    }

    public void TakeDamage()
    {
        _currentHealth -= _damage;

        if (_currentHealth > 0)
        {
            HealthChanged?.Invoke(_currentHealth);
        }
        else
        {
            _currentHealth = 0;
            HealthChanged?.Invoke(_currentHealth);
        }
    }
}
