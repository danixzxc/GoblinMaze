using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{

    public NavMeshAgent agent;

    public List<Transform> movePoints;
    private int _currentPointIndex;
    private bool _chasePlayer;
    private GameObject playerGameObject;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerGameObject = FindObjectOfType<PlayerMovement>().gameObject;
        _currentPointIndex = 0;
        agent.SetDestination(movePoints[_currentPointIndex].position);
        _chasePlayer = false;
    }


    void Update()
    {
        if (_chasePlayer)
        {
            agent.SetDestination(playerGameObject.transform.position);
        }
        else
        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            FindNewDestination();
        }

    }

    private void FindNewDestination()
    {
        if (_currentPointIndex == movePoints.Count - 1)
        {
            _currentPointIndex = 0;
        }
        else
        {
            _currentPointIndex++;
        }
        agent.SetDestination(movePoints[_currentPointIndex].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            _chasePlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            _chasePlayer = false;
            agent.SetDestination(movePoints[_currentPointIndex].position);
        }
    }
}