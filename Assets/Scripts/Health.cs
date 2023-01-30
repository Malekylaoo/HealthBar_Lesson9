using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public event UnityAction<float> HealthChanged;

    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(int heal)
    {
        _currentHealth += heal;

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        HealthChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        HealthChanged?.Invoke(_currentHealth);
    }
}
