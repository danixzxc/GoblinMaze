using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorWinner : MonoBehaviour
{
    public UnityEvent win;

    private void OnTriggerEnter(Collider other)
    {
        ItemPicker itemPicker = other.GetComponent<ItemPicker>();
        if (itemPicker != null)
        {
            if (itemPicker.keyAmount >= 3)
            {
                win?.Invoke();
                Debug.Log("YOU WON");
            }
        }
    }
}
