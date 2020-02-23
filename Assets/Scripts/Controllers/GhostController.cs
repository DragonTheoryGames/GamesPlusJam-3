using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour
{
    [SerializeField] float inputFrequency = 0.25f;
    private NavMeshAgent agent;
    private Camera cam;
    private RaycastHit hitInfo;
    private float timer = 0.0f;

    [SerializeField] int mouseButton;
    [SerializeField] float range;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetMouseButton(mouseButton) && timer > inputFrequency)
        {
            if (!agent.isStopped) agent.ResetPath();
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity)) agent.SetDestination(hitInfo.point);
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }
}
