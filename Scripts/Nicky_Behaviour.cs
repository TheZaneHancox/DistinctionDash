using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nicky_Behaviour : MonoBehaviour {
    public GameObject shop_screen;
    private Transform marker1, marker2;
    private float marker1_distance;
    private bool move = true;
    [SerializeField]
    private float speed;
    private Player_Behaviour player_behaviour;
    private int num_jellies; 
    private int player_state = 1; //1 = default state
    private Transform pointer_1, pointer_2;
    private float pointer_1_dist, pointer_2_dist, step;
    private bool change_direction;
    private float waitTime;
    public float startWaitTime;

    //Movement stuffs
    public Transform[] pointers;
    private int movement_state;
    public float min_X, min_y, max_X, max_y;
    public Transform moveSpot;

    private void Start()
    {
        player_behaviour = new Player_Behaviour();
        num_jellies = player_behaviour.jellybeancounter;
        movement_state = Random.Range(0, pointers.Length);
        waitTime = startWaitTime;
    }

    private void Update()
    {
        //movement
        transform.position = Vector2.MoveTowards(transform.position, pointers[movement_state].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, pointers[movement_state].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                movement_state = Random.Range(0, pointers.Length);
                waitTime = startWaitTime;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }

    public void PurchaseSleepDart()
    {
        if(player_behaviour.jellybeancounter >= 40)
        {
            //purchase item
            num_jellies -= 40;
        }
    }

    public void PurchaseFlameThrower()
    {
        if(player_behaviour.jellybeancounter >= 500)
        {
            //purchase item
            num_jellies -= 500;
        }
    }

    public void PurchaseRevivePhil()
    {
        if(player_behaviour.jellybeancounter >= 100)
        {
            //purchase item
            num_jellies -= 100;
        }
    }

    public void PurchaseMysteryPowerup()
    {
        if(player_behaviour.jellybeancounter >= 200)
        {
            //purchase item
            num_jellies -= 200;
        }
    }

    public void PurchaseGuitarBooster()
    {
        if(player_behaviour.jellybeancounter >= 75)
        {
            //purchase item
            num_jellies -= 75;
        }
    }

    public void PurchaseQuestClue()
    {
        if (player_behaviour.jellybeancounter >= 50)
        {
            //purchase item
            num_jellies -= 50;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shop_screen.SetActive(!shop_screen.activeSelf);
        }
    }
}
