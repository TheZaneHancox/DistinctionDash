using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerupBar : MonoBehaviour {

    public Sprite[] states;
    public int statelevel = 0;
    public Image powerbarUI;
    private float timer = 0.0f;
    private float waitingTime = 5.0f; //5 second wait time.

	// Use this for initialization
	void Start () {
        //StartCoroutine(PowerBarCoroutine());
    }
	
	// Update is called once per frame
	void Update () {
        powerbarUI.sprite = states[statelevel];
        timer += Time.deltaTime;
        if (Input.GetKeyDown("space") && statelevel == 3)
        {
            //do the powerup:

            //reset the bar:
            statelevel = 0;
        }
        else
        {
            if (timer > waitingTime)
            {
            timer = 0f;
                if (statelevel != 3)
                {
                    statelevel += 1;
                }
                else { }
            }
        }
    }
}
