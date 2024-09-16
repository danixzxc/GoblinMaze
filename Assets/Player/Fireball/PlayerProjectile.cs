using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField]
    private float launchSpeed = 10f;
    [SerializeField]
    private float selfDestroyAfter = 5f;
    [SerializeField]
    private AnimationCurve sizeOverTime = AnimationCurve.Linear(1f, 1f, 1f, 1f);

    private float lifetime = 0.0f;

    private void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= selfDestroyAfter)
        {
            Destroy(this.gameObject);
        }
        float size_axis = sizeOverTime.Evaluate(lifetime/selfDestroyAfter);
        transform.localScale = new Vector3(size_axis, size_axis, size_axis);

    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageableEnemy enemy = collision.collider.gameObject.GetComponent<DamageableEnemy>();
        if (enemy != null)
        {
            enemy.RecieveDamage();
        }
    }

    public void Launch(Vector3 direction)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(rb);
        rb.AddForce(direction.normalized*launchSpeed, ForceMode.Impulse);
    }
}
