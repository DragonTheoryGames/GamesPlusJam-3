using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I know its a bit of a copy, trying to save time since this took awhile.

public class EnterClose : MonoBehaviour
{
    public GameObject door;
    public float yEnterRotation;
    public bool plus;
    public bool negative;
    public GameObject exitEnable;
    public GameObject closeDoorDisabled;



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
               
            door.transform.Rotate(0, yEnterRotation, 0);
            closeDoorDisabled.GetComponent<Collider>().enabled = false;
            //Turning this back on
            exitEnable.GetComponent<Collider>().enabled = true;
        }      
    }
}
