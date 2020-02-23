using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    // Dictates whether the enemy waits on each node.
    [SerializeField]
    bool patrolWaiting;

    // The total time we wait at each node
    [SerializeField]
    float totalWaitTime = 3f;

    // The probability of switching direction
    [SerializeField]
    float switchProbability = 0.2f;

    // The list of all patrol nodes to visit
    [SerializeField]
    List<EnemyWaypoint> patrolPoints;

    // Private variables for base behavior
    NavMeshAgent agent;
    int currentPatrolIndex;
    bool travelling;
    bool waiting;
    bool patrolForward;
    float waitTimer;

    public void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        if (patrolPoints != null && patrolPoints.Count >= 2)
        {
            currentPatrolIndex = 0;
            // TO DO: Need to check if the enemy is chasing the player, if so then don't set destination
            SetDestination();
        }
    }

    public void Update()
    {
        // Check if we're close to the destination
        if (travelling && agent.remainingDistance <= 1.0f)
        {
            travelling = false;

            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        // Instead if we're waiting
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= totalWaitTime)
            {
                waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if (patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            agent.SetDestination(targetVector);
            travelling = true;
        }
    }

    private void ChangePatrolPoint()
    {
        if (Random.Range(0f, 1f) <= switchProbability)
        {
            patrolForward = !patrolForward;
        }

        if (patrolForward)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        }
        else
        {
            if (--currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.Count - 1;
            }
        }
    }
}
