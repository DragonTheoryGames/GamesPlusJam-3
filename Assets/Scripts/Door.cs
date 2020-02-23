using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    public float yRotation;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision doorMove)
    {
        if(doorMove.gameObject.name == "Agent")
        {
            door.transform.Rotate(0, yRotation, 0);
        }
    }

    void OnCollisionExit(Collision doorClose)
    {
        door.transform.Rotate(0, yRotation, 0);
    }

}
