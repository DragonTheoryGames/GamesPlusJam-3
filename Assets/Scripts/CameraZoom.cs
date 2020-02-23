using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCam;

    [SerializeField] List<Transform> targets; //list of player and agent.
    [SerializeField] Vector3 offset; //camera position controls.
    Vector3 sdVelocity;
    [SerializeField] float smoothTime = .5f;

    [Tooltip("Minimum Camera distance from Player")]
    [SerializeField] float zoom;

    [SerializeField] Transform agent;
    Vector3 lastPos = new Vector3(0,0,0);
    float lastTime = 0;

    void FixedUpdate() 
    {
        AgentFocus();
    }

    void LateUpdate() 
    {
        MoveCam();
        ZoomCam();
    }

    void AgentFocus()
    {
        if ((Time.time - lastTime) > 1)
        {
            if (agent.position != lastPos && targets.Count < 3)
            {
                targets.Add(agent);
                lastPos = agent.position;
            }
            else
            {
                targets.Remove(agent);
            }
            lastTime = Time.time;
        }
        
    }

    void MoveCam()
    {
        Vector3 cameraTargetPos = GetCenterPoint() + offset;
        transform.position = Vector3.SmoothDamp(transform.position, cameraTargetPos, ref sdVelocity, smoothTime);
    }

    void ZoomCam()
    {
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero); //Bounds is crazy, recommend you don't touch.
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        if (bounds.size.x > bounds.size.y)
        {
            zoom = bounds.size.x;
        }
        else 
        {
            zoom = bounds.size.y;
        }
        zoom = ((zoom / 3) + 100);
        
        vCam.m_Lens.FieldOfView = zoom;
    }

    Vector3 GetCenterPoint() //returns a point central to all Transforms included in targets
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        Bounds bounds = new Bounds(targets[0].position, Vector3.zero); //Bounds is crazy, recommend you don't touch.
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

    
}
