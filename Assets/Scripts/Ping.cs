using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour
{
    public GameObject ping;
    public GameObject pingClone;
    public bool destroy;
    public int pings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray pingCast = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit pingHitCast;

         if(Input.GetMouseButtonDown(1))
            {
                StartCoroutine(Timer());
                if(Physics.Raycast(pingCast, out pingHitCast, 100))
                {  
                    pingClone = Instantiate(ping, pingHitCast.point, Quaternion.identity);
                    Destroy(pingClone, 3);      
                }
                StopCoroutine(Timer());
                StartCoroutine(Timer());
                StopCoroutine(Timer());
            }
    }
    
    public IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(10);
        
    }
    
}
