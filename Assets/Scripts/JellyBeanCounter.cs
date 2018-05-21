using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JellyBeanCounter : MonoBehaviour {

    public Text counter;
    public Player_Behaviour player;
    private int amount;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<Player_Behaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        amount = player.jellybeancounter;
        counter.text = amount + " Jelly Beans";
    }
}
