using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class Agent : MonoBehaviour
{
    public GameObject npcTarget;
    public GameObject npcStatic;
    public GameObject npcTemp;
    public NavMeshAgent navMeshAgent;   
    public GameObject ping;
    private GameObject nullTarget;

    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) //Creates a Ping
            {  
                Debug.Log("click");
                navMeshAgent.SetDestination(npcTarget.transform.position);
                Ray pingCast = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit pingHitCast;

                if(Physics.Raycast(pingCast, out pingHitCast, 100))
                {  
                    npcTemp = Instantiate(ping, pingHitCast.point, Quaternion.identity);
                    npcTarget = npcTemp; //Sets the Agent target to the latest ping
                    
                    Destroy(npcTemp, 3); //Destroys it after;
                    
                }
            }
        
            else
            {
                 npcTarget = npcStatic; //Sets the Agent target back to the original, a placeholder of the prefab
            }

            
    }
}
