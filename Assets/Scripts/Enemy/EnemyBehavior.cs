using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    public bool targettingPlayer;

    private EnemySight sight;
    private EnemyPatrol patrol;
    private Vector3 NPCLastSeen;
    private NavMeshAgent agent;

    void Start()
    {
        sight = GetComponent<EnemySight>();
        patrol = GetComponent<EnemyPatrol>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        while (sight.isInFov)
        {
            targettingPlayer = true;
            followPlayer();
        }
    }

    public void followPlayer()
    {
        agent.SetDestination(sight.NPC.position);
    }
}
