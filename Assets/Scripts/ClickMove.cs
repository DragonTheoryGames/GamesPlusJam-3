using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMove : MonoBehaviour
{

    public GameObject ghost;
    CapsuleCollider ghostCollider;
    public float moveDisPerSec = 1;

    Vector3 destination;

    // Start is called before the first frame update
    private void Start()
    {
        destination = ghost.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                destination.x = hit.point.x;
                destination.y = 3;
                destination.z = hit.point.z;
            }

        }
    }

    // Ladies and gentleman,
    // My junky fix
    // - Script
    private void FixedUpdate()
    {
        float dis = Vector3.Distance(ghost.transform.position, destination);

        if (dis > 0)
        {
            float moveDis = Mathf.Clamp(moveDisPerSec * Time.fixedDeltaTime, 0, dis);

            Vector3 move = (destination - transform.position).normalized * moveDis;

            ghost.transform.Translate(move);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Enemy" || collision.transform.tag != "BorderWall")
        {
            ghostCollider = ghost.GetComponent<CapsuleCollider>();

            ghostCollider.enabled = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ghostCollider = ghost.GetComponent<CapsuleCollider>();

        ghostCollider.enabled = true;
    }
}

