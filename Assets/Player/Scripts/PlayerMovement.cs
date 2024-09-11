using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Assert.IsNotNull(controller);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move_direction = transform.forward * Input.GetAxis("Vertical");
        move_direction += transform.right * Input.GetAxis("Horizontal");
        move_direction = move_direction.normalized * speed;
        bool grounded = controller.SimpleMove(move_direction);

    }
}
