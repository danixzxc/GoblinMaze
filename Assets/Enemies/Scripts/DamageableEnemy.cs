using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableEnemy : MonoBehaviour
{
    public UnityEvent onDamage;
    public void RecieveDamage()
    {
        Debug.Log("HELP");
        onDamage?.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
