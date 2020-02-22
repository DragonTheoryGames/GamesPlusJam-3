using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class Agent : MonoBehaviour
{
    public GameObject npcTarget;
    public NavMeshAgent navMeshAgent;   

    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(npcTarget.transform.position);
    }
}
