using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class PlayerAttacker : MonoBehaviour
{
    private Transform player;
    public float attackDistance = 2.0f;
    private float sqrAttackDistance;
    public LayerMask layerMask;
    public CooldownTimer cooldown;
    public UnityEvent<RaycastHit> playerAttacked;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Assert.IsNotNull(player);
        sqrAttackDistance = attackDistance * attackDistance;
        Assert.IsNotNull(cooldown);
    }

    public void Update()
    {
        if ((player.position - transform.position).sqrMagnitude <= sqrAttackDistance)
        {
            RaycastHit hitInfo;
            bool result = Physics.Raycast(transform.position + new Vector3(0f, 0.5f, 0f), transform.forward, out hitInfo, attackDistance, layerMask);
            if (result)
            {
                Debug.DrawRay(transform.position + new Vector3(0f, 0.5f, 0f), transform.forward * attackDistance);
                if (cooldown.IsAble())
                {
                    cooldown.Activate();
                    playerAttacked?.Invoke(hitInfo);
                    //Debug.Log(hitInfo.collider.gameObject.name);
                    hitInfo.collider.GetComponent<HealthComponent>().health -= 1;
                }
            }
        }
    }
}
