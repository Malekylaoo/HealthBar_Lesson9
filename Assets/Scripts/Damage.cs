using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Health _health;

    public void GiveDamage()
    {
        _health.TakeDamage(_damage);
    }
}
