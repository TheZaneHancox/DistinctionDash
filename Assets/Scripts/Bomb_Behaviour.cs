using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Behaviour : MonoBehaviour {

    public GameObject thisbomb;

    //audio stuffs
    public AudioClip Explosion_Sound;
    public float soundvolume;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audio.PlayOneShot(Explosion_Sound, soundvolume);
        }
    }
}
