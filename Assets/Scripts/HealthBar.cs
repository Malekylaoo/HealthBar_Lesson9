using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;
    [SerializeField] private float _speed;

    private Coroutine _coroutine; 
    private float _currentHealth;
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _currentHealth = _maxHealth;
        _slider.value = _maxHealth;
    }

    private IEnumerator ChangeValue(float target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, Time.deltaTime * _speed); ;
            yield return null;
        }
    }

    private void StartChangeValue(Coroutine coroutine)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = coroutine;
    }

    private void TakeDamage()
    {
        _currentHealth -= _damage;

        if (_currentHealth > 0)
        {
            StartChangeValue(StartCoroutine(ChangeValue(_currentHealth)));
        }
        else
        {
            _currentHealth = 0;
            StartChangeValue(StartCoroutine(ChangeValue(_currentHealth)));
        }
    }

    private void Heal()
    {
        _currentHealth += _heal;

        if (_currentHealth <= _maxHealth)
            StartChangeValue(StartCoroutine(ChangeValue(_currentHealth)));
        else
            _currentHealth = _maxHealth;
    }

    
}
