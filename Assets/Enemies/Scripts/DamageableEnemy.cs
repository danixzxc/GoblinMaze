using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableEnemy : MonoBehaviour
{
    public UnityEvent onDamage;
    public void RecieveDamage()
    {
        onDamage?.Invoke();
    }
}
