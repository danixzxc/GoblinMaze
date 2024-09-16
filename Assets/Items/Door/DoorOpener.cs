using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        ItemPicker itemPicker = other.GetComponent<ItemPicker>();
        if (itemPicker != null)
        {
            if (itemPicker.keyAmount >= 3)
            {
                Destroy(door);
                Destroy(this.gameObject);
            }
        }
    }
}
