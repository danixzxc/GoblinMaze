using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public int startingHP = 5;
    public UnityEvent<int> healthChanged;
    public UnityEvent healthEnded;

    private int _health;
    public int health
    {
        get { return _health; }
        set
        {
            _health = value;
            if (health < 0)
            {
                health = 0;
                healthEnded.Invoke();
            }
            healthChanged.Invoke(_health);
        }
    }

    public void Start()
    {
        health = startingHP;
    }

    public void RecieveDamage(int amount)
    {
        health -= amount;
    }
}
