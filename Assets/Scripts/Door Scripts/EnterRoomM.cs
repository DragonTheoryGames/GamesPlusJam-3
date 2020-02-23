using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I added an extra M as Unity was fucking up saying the namespace was already declared or some shit.
public class EnterRoomM : MonoBehaviour
{
    public GameObject door;
    public float yEnterRotation;
    public float yEnterRotationHolder;
    public GameObject enter;
    public GameObject exit;
    public GameObject closeEnable;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    void OnTriggerEnter(Collider doorMove)
    {
        if(doorMove.gameObject.name == "Agent")
        {
            enter.GetComponent<Collider>().enabled = false;
            exit.GetComponent<Collider>().enabled = false;
            door.transform.Rotate(0, yEnterRotation, 0);
                
              
                
            //Turning off the collider to prevent the door from moving again until it is time

                closeEnable.GetComponent<Collider>().enabled = true;
        }
                    
    }   
               
    

}
