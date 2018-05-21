using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu : MonoBehaviour {

    //audio stuffs
    public AudioClip soundFile;
    public float soundvolume;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(soundFile, soundvolume);
    }
}
