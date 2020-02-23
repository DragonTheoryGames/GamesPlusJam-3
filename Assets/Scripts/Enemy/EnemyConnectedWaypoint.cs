using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConnectedWaypoint : EnemyWaypoint
{

    [SerializeField]
    protected float connectivityRadius = 50f;

    List<EnemyConnectedWaypoint> connections;

    public void Start()
    {
        // Grab all waypoints in scene
        GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        // Create a list of waypoints I can refer to later
        connections = new List<EnemyConnectedWaypoint>();

        for (int i = 0; i < allWaypoints.Length; i++)
        {
            EnemyConnectedWaypoint nextWaypoint = allWaypoints[i].GetComponent<EnemyConnectedWaypoint>();

            // We find a waypoint
            if (nextWaypoint != null)
            {
                if (Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= connectivityRadius && nextWaypoint != this)
                {
                    connections.Add(nextWaypoint);
                }
            }
        }
    }

    public override void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, connectivityRadius);
    }

    public EnemyConnectedWaypoint NextWaypoint(EnemyConnectedWaypoint previousWaypoint)
    {
        if (connections.Count == 0 )
        {
            Debug.LogError("Need waypoints! NOW!");
            return null;
        }
        else if (connections.Count == 1 && connections.Contains(previousWaypoint))
        {
            return previousWaypoint;
        }
        else
        {
            EnemyConnectedWaypoint nextWaypoint;
            int nextIndex = 0;

            do
            {
                nextIndex = Random.Range(0, connections.Count);
                nextWaypoint = connections[nextIndex];
            }
            while (nextWaypoint == previousWaypoint);

            return nextWaypoint;
        }
    }

}
