using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;

    private float _currentHealth;
    private PlayerInput _playerInput;
    private Slider _slider;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _slider = GetComponent<Slider>();
        _currentHealth = _maxHealth;
        _slider.value = _maxHealth;
    }

    private void Start()
    {
        _playerInput.Player.TakeDamage.performed += ctx => TakeDamage();
        _playerInput.Player.Heal.performed += ctx => Heal();  
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void TakeDamage()
    {
        if(_currentHealth > 0)
        {
            _currentHealth -= _damage;
            ChangeValue(_currentHealth);
        }
    }

    public void Heal()
    {
        _currentHealth += _heal;
        if (_currentHealth <= _maxHealth)
            ChangeValue(_currentHealth);
        else
            _currentHealth = _maxHealth;
    }

    public void ChangeValue(float value)
    {
        _slider.value = value;
    }    
}
