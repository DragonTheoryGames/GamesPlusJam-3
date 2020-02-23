using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRoom : MonoBehaviour
{
    public GameObject door;
    public float yExitRotation;
    public float yExitRotationHolder;
    public GameObject enter;
    public GameObject exit;
    public GameObject exitEnable;


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
        if(doorMove.gameObject.name == "Ghost")
        {
            exit.GetComponent<Collider>().enabled = false;
            enter.GetComponent<Collider>().enabled = false;
            GameObject.Find("Door Enter Trigger").GetComponent<Collider>().enabled = false;
            door.transform.Rotate(0, yExitRotation, 0); 
        }

            //Turning off the collider to prevent the door from moving again until it is time
            exitEnable.GetComponent<Collider>().enabled = true;
            
    }   
               
}
