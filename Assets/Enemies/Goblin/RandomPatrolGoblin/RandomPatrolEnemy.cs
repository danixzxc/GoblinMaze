using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //important

//if you use this code you are contractually obligated to like the YT video
public class RandomPatrolEnemy : MonoBehaviour //don't forget to change the script name if you haven't
{
    public NavMeshAgent agent;
    public float range; //radius of sphere

    public Transform centrePoint;

    private bool _chasePlayer;
    private GameObject playerGameObject;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerGameObject = FindObjectOfType<PlayerMovement>().gameObject;
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
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
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
        }
    }
}