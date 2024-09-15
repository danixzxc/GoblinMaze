using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FireballLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject fireball;

    public Transform head;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject instance = Instantiate(fireball);
            PlayerProjectile projectile = instance.GetComponent<PlayerProjectile>();
            Assert.IsNotNull(projectile);
            instance.transform.position = transform.position;
            projectile.Launch(head.forward);
        }
    }
}
