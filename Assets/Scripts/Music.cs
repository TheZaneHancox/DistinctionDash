using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    //audio stuffs
    [SerializeField]
    public AudioClip soundtrack;
    public float soundvolume;
    public AudioSource audio;

    // Use this for initialization
    void Start () {
        audio.PlayOneShot(soundtrack, soundvolume);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
