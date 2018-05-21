using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile_Behaviour : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Transform target;
    private Animator anim;
    public Player_Behaviour player;

    [SerializeField]
    private float character_speed;

    private float player_distance;

    //public AudioClip soundFile;
    //public float soundvolume;
    //AudioSource audio;

    // Use this for initialization
    void Start () {
        //audio = GetComponent<AudioSource>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").GetComponent<Player_Behaviour>();
    }
	
	// Update is called once per frame
	void Update () {
        if(player.isalive)
        {
            player_distance = Vector3.Distance(transform.position, target.position);
        }
        //Debug.Log(player_distance);

        if (player_distance <= 20)
        {
            if (speed > 0.01)
            {
                anim.SetFloat("Speed", Mathf.Abs(character_speed));
                /*while (speed > 0.01)
                {
                    character_speed += 0.25f; //gradually gets faster when chasing  

                    //play capture audio
                    audio.PlayOneShot(soundFile, soundvolume);
                }*/
            }
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Vector3 player_view = Input.mousePosition;
            player_view = Camera.main.ScreenToWorldPoint(player_view);
            Vector2 direction = new Vector2(player_view.x - transform.position.x, player_view.y - transform.position.y);
            transform.up = direction;
        }
	}
}
