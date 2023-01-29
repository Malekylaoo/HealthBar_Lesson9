using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _coroutine; 
    private Slider _slider;
    private Health _heatlh;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _heatlh = GetComponent<Health>();
    }

    private void Start()
    {
        _slider.value = _heatlh.MaxHealth;
    }

    private void OnEnable()
    {
        _heatlh.HealthChanged += StartCoroutine;
    }

    private void OnDisable()
    {
        _heatlh.HealthChanged -= StartCoroutine;
    }

    private IEnumerator ChangeValue(float target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, Time.deltaTime * _speed);
            yield return null;
        }
    }

    private void StartChangeValue(Coroutine coroutine)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = coroutine;
    }

    private void StartCoroutine(float value)
    {
        StartChangeValue(StartCoroutine(ChangeValue(value)));
    }
}
