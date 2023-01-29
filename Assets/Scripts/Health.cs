using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBar))]
public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;

    private HealthBar _healthBar;
    private float _currentHealth;

    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _healthBar = GetComponent<HealthBar>();
        _currentHealth = _maxHealth;
    }

    public void Heal()
    {
        _currentHealth += _heal;

        if (_currentHealth <= _maxHealth)
        {
            _healthBar.StartCoroutine(_currentHealth);
        }
        else
        {
            _currentHealth = _maxHealth;
            _healthBar.StartCoroutine(_currentHealth);
        }    
    }

    public void TakeDamage()
    {
        _currentHealth -= _damage;

        if (_currentHealth > 0)
        {
            _healthBar.StartCoroutine(_currentHealth);
        }
        else
        {
            _currentHealth = 0;
            _healthBar.StartCoroutine(_currentHealth);
        }
    }
}
