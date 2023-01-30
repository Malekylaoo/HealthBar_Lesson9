using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _heal;
    [SerializeField] private Health _health;

    public void GiveHeal()
    {
        _health.Heal(_heal);
    }
}
