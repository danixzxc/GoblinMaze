using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ItemPicker : MonoBehaviour
{
    public UnityEvent onPickupKey;
    [SerializeField]
    private List<Image> _images;
    private int _itemIndex = 0;
    public int keyAmount = 0;

    private void OnTriggerEnter(Collider other)
    {
        PickUp pickUp = other.gameObject.GetComponent<PickUp>();
        if (pickUp != null)
        {
            if (pickUp.type == PickUp.Type.KEY)
            {
                onPickupKey.Invoke();
                _images[_itemIndex].color = new Color(_images[_itemIndex].color.r,
                    _images[_itemIndex].color.g, _images[_itemIndex].color.b, 1f);
                _itemIndex++;
                keyAmount++;
            }
            pickUp.PickUpInvoke();
        }
    }
}
