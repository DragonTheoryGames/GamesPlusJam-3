using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OldClickMove : MonoBehaviour
{
    public NavMeshAgent ghostAgent;

    // Start is called before the first frame update
    void Start()
    {
        ghostAgent = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
             Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitCast;
            
            if(Physics.Raycast(rayCast, out hitCast, 100))
            {
                ghostAgent.destination = hitCast.point;
            }
        }
    }
    
}

