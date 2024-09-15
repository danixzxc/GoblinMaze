using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{


    public enum Type
    {
        NONE,
        KEY
    }

    public Type type = Type.NONE;
    public UnityEvent onPickUp;
    public bool DestroyOnPickUp = true;
    public void PickUpInvoke()
    {
        onPickUp?.Invoke();
        if (DestroyOnPickUp)
        {
            Destroy(this.gameObject);
        }
    }
}
