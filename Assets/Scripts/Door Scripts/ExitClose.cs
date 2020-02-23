using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitClose : MonoBehaviour
{
public GameObject door;

    public float yExitRotation;
    public bool plus;
    public bool negative;
    public GameObject enterEnable;
    public GameObject exitEnableDisabled;



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
                    door.transform.Rotate(0, yExitRotation, 0);
                    exitEnableDisabled.GetComponent<Collider>().enabled = false;
                    //Turning this back on
                    enterEnable.GetComponent<Collider>().enabled = true;
        }      
    }
}
