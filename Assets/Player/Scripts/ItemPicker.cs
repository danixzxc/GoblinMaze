using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ItemPicker : MonoBehaviour
{
    public UnityEvent onPickupKey;

    private void OnTriggerEnter(Collider other)
    {
        PickUp pickUp = other.gameObject.GetComponent<PickUp>();
        if (pickUp != null)
        {
            if (pickUp.type == PickUp.Type.KEY)
            {
                onPickupKey.Invoke();
            }
            pickUp.PickUpInvoke();
        }
    }
}
