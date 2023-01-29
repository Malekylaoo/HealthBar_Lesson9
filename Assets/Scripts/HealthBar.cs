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

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _heatlh = GetComponent<Health>();

        _slider.value = _heatlh.MaxHealth;
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

    public void StartCoroutine(float value)
    {
        StartChangeValue(StartCoroutine(ChangeValue(value)));
    }
}
