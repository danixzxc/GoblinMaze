using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform head;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        head.localEulerAngles = new Vector3(head.localEulerAngles.x - Input.GetAxis("Mouse Y"), 0, 0);
    }
}
