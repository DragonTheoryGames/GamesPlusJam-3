using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAudio : MonoBehaviour
{
    public AudioSource evpSource;

    private void Start() 
    {
        evpSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (Input.GetMouseButton(1))
        {
            evpSource.Play();
        }
    }
}
