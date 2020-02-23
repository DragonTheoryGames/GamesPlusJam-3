using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Transform doorObject;
    [SerializeField] float openTime = 0.5f;
    private Collider col;
    private List<Collider> collidingList = new List<Collider>();
    private Quaternion openRotation, initialRotation;
    private bool opened = false;

    private void Start()
    {
        col = doorObject.GetComponent<Collider>();
        initialRotation = transform.rotation;
        openRotation = Quaternion.LookRotation(transform.right);
    }

    private void Update()
    {
        if (collidingList.Count > 0)
        {
            if (!opened) StartCoroutine(OpenDoor());
        }
        else if (opened) StartCoroutine(CloseDoor());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!collidingList.Contains(other)) collidingList.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (collidingList.Contains(other)) collidingList.Remove(other);
    }

    private IEnumerator OpenDoor()
    {
        col.enabled = false;
        opened = true;
        float t = 0.0f, step = 0.0f;
        while (t < openTime)
        {
            step = Mathf.SmoothStep(0.0f, 1.0f, t / openTime);
            doorObject.rotation = Quaternion.Slerp(initialRotation, openRotation, step);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator CloseDoor()
    {
        opened = false;
        float t = 0.0f, step = 0.0f;
        while (t < openTime)
        {
            step = Mathf.SmoothStep(1.0f, 0.0f, t / openTime);
            doorObject.rotation = Quaternion.Slerp(initialRotation, openRotation, step);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        col.enabled = true;
    }
}
