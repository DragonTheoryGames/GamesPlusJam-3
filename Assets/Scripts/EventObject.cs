using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : MonoBehaviour
{

    /// <summary>
    ///  This file will be used to contain properties of an object
    /// </summary>

    // If the object can be reused, or if it has already been used
    public bool isReusable;
    public bool isUsable;

    // Audio for the object
    public AudioClip objAudio;
    public float audioVolume;
    AudioSource Audio;



    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void Run()
    {
        Audio.PlayOneShot(objAudio, audioVolume);
    }

}
