using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{

    private EnemyBehavior behavior;

    // Dictates whether the enemy waits on each node.
    [SerializeField]
    bool patrolWaiting;

    // The total time we wait at each node
    [SerializeField]
    float totalWaitTime = 3f;

    // Private variables for base behavior
    NavMeshAgent agent;
    EnemyConnectedWaypoint currentWaypoint;
    EnemyConnectedWaypoint previousWaypoint;

    int currentPatrolIndex;
    bool travelling;
    bool waiting;
    float waitTimer;
    int waypointsVisited;

    public void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        behavior = this.GetComponent<EnemyBehavior>();

        if (currentWaypoint == null)
        {
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

            if (allWaypoints.Length > 0)
            {
                while (currentWaypoint == null)
                {
                    int random = Random.Range(0, allWaypoints.Length);
                    EnemyConnectedWaypoint startingWaypoint = allWaypoints[random].GetComponent<EnemyConnectedWaypoint>();

                    // We found a waypoint
                    if (startingWaypoint != null)
                    {
                        currentWaypoint = startingWaypoint;
                    }
                }
            }
            else
            {
                Debug.LogError("Failed to find waypoints in this scene. NEED WAYPOINTS. NOW!");
            }
        }

        SetDestination();
    }

    public void Update()
    {
        // Check if we're close to the destination
        if (travelling && agent.remainingDistance <= 1.0f)
        {
            travelling = false;
            waypointsVisited++;

            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
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

                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if (waypointsVisited > 0)
        {
            EnemyConnectedWaypoint nextWaypoint = currentWaypoint.NextWaypoint(previousWaypoint);
            previousWaypoint = currentWaypoint;
            currentWaypoint = nextWaypoint;
        }

        Vector3 targetVector = currentWaypoint.transform.position;
        agent.SetDestination(targetVector);
        travelling = true;
    }
}
