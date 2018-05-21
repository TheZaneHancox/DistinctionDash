using System;
using UnityEngine;
using UnityEngine.UI;

public class Player_Behaviour : MonoBehaviour {

    public float speed = 1.0f;
    public float speedrotate = 5.0f;
    Animator anim;
    public int jellybeancounter = 0;
    private Camera mainCamera;
    public GameObject camera, explosion;
    public bool isalive = true; //accessed via Hostile_Behaviour to reduce errors created when game object is disabled.
    public Text respawn;
    private int item_state;

    //Health Counter (hearts)
    public Sprite[] HeartSprites;
    public Image HeartUI;
    public GameObject player;
    private Transform spawn_point;
    public int cur_health = 0;

    [SerializeField]
    private GameObject gameOverUI;

    //audio stuffs
    public AudioClip soundFile, GameOverMusic, Explosion_Sound;
    public float soundvolume;
    AudioSource audio;

    //useful functions
    private void LivesRemainingRespawn()
    {
        int second = 5;
        bool secondlimit = true;
        if(cur_health == 5)
        {
            EndGame();
        }
        else {
            Respawn();
        }


        /*if(cur_health < 5)
        {
            while(secondlimit)
            {
                //here i will do the respawn counter
                respawn.text = "Repawning in: " + second + " seconds ";
                //System.Threading.Thread.Sleep(1000); //1 second wait time
                second -= 1;
                if (second == 5)
                {
                    Respawn();
                    secondlimit = false;
                }
            }
        } else
        {
            EndGame();
        }*/
    }
    private void BombTrigger()
    {
        Damage(1);
        respawn.text = "TRIGGERDDD";
        if (cur_health == 5)
        {
            EndGame();
        }
        else
        {
            gameObject.SetActive(true);
            player.transform.position = spawn_point.transform.position;
            isalive = true;
            respawn.text = "activated";
        }
        isalive = false;
    }
    private void Respawn()
    {
        gameObject.SetActive(true);
        player.transform.position = spawn_point.transform.position;
        isalive = true;
    }
    private void EndGame()
    {
        gameOverUI.SetActive(true);
    }
    private void LookAtMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
    private void Movement()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(axisX, axisY) * Time.deltaTime * speed);
        anim.SetFloat("Speed", Mathf.Abs(axisX));
        anim.SetFloat("Speed", Mathf.Abs(axisY));
        LookAtMouse();
    }
    private void Damage(int damage)
    {
        cur_health += damage;
    }

    //executed when game is started
    void Start () {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        mainCamera = FindObjectOfType<Camera>();
        //player = GameObject.FindGameObjectWithTag("Player");
        spawn_point = GameObject.FindGameObjectWithTag("Spawn_Point").transform;
    }

    //executes (updates) every frame
    void Update () {
        Movement();
        HeartUI.sprite = HeartSprites[cur_health];
    }
    //executes when triggered by a collision with main player (e.g. bomb etc.)
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            audio.PlayOneShot(soundFile, soundvolume);
            collision.gameObject.SetActive(false);
            jellybeancounter += 1;
        }
        else if (collision.gameObject.CompareTag("SecurityGuard"))
        {
            EndGame();
            audio.PlayOneShot(GameOverMusic, soundvolume);
            Debug.Log("Captured");
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {
            Instantiate(explosion, transform.position, transform.rotation = Quaternion.identity); //Quaternion.identity sets object rotation to (0,0)
            BombTrigger();
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }

   

}
