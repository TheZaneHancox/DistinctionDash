using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dave_Behaviour : MonoBehaviour {

    private Animator anim;

    [SerializeField]
    private float character_speed;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
    void Movement()
    {
        anim.SetFloat("Speed", Mathf.Abs(character_speed));
    }


	// Update is called once per frame
	void Update () {
	}
}
