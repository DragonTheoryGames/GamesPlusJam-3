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
    public Transform theAgent;

    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(npcTarget.transform.position);
        Ray pingCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray agentCast = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit pingHitCast;
        //RaycastHit agentHitCast;

         if(Input.GetMouseButtonDown(1))
            {
                StartCoroutine(Timer());
                if(Physics.Raycast(pingCast, out pingHitCast, 100))
                {  
                    npcTemp = Instantiate(ping, pingHitCast.point, Quaternion.identity);
                    npcTarget = npcTemp;
                    
                    Destroy(npcTemp, 3);
                    
                }
                StopCoroutine(Timer());
            }
            else
            {
                npcTarget = npcStatic;
            }

            
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(10);
        
    }
}
