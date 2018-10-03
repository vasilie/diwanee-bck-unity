using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    private float actualDistance;
    public GameObject score;

    public string[] paddleList;
    public int currentPaddle = 3;

    public Transform fireEff;
    [SerializeField]
    //private float speed = 1.0f;
    private Vector3 playerPos;
    float xPos;

    public AudioClip[] sounds;
    private AudioSource audPlayer;

    public bool firebalActive = false;
    public bool gunActive = false;



    private Vector3 linearDistanceVector;
    private Vector3 mousePosition;

    private GunHolder gunHolder;

    public GameObject ball;
    public GameObject ballPrefab;

    private Transform paddle;
    private Vector3 finalPosition;
    private Camera cam;

    private GameObject ballClone;

    public GameObject bulletPrefab;

   

    // Use this for initialization
    void Start () {
        gunHolder = transform.Find("GunHolder").GetComponent<GunHolder>();
        audPlayer = GetComponent<AudioSource>();
        cam = Camera.main;
        paddleList = new string[] { "Paddle-3", "Paddle-2", "Paddle-1", "PaddleRegular", "Paddle+1", "Paddle+2", "Paddle+3" };

        ball = GameObject.Find("Ball");
       
        Vector3 toObjectVector = new Vector3();

        toObjectVector = transform.position - cam.transform.position;
        linearDistanceVector = Vector3.Project(toObjectVector, cam.transform.forward);
        actualDistance = linearDistanceVector.magnitude;

        playerPos = gameObject.transform.position;
        xPos = playerPos.x;
        paddle = transform.Find("Paddle");
       
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    void Update () {

       
        mousePosition = Input.mousePosition;
        mousePosition.z = actualDistance;
        //mousePosition.x = Mathf.Clamp(mousePosition.x, -154.0f, 58f);
        finalPosition = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mousePosition.z));
        finalPosition.z = 94.9f;
        finalPosition.y = 2.6f;
        finalPosition.x = Mathf.Clamp(finalPosition.x, -192.0f, 96.3f);
        transform.position = finalPosition;
        //xPos = - Input.mousePosition.x;
        //Debug.Log(xPos);
        //xPos = Mathf.Clamp(xPos, -154.0f, 58f);

        //playerPos = new Vector3(xPos, gameObject.transform.position.y, gameObject.transform.position.z);
        //transform.position = playerPos;
        if (Input.GetButtonDown("Fire1") && gunActive){
            gunHolder.Shoot();
            audPlayer.clip = sounds[0];
            audPlayer.Play();
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "powerup"){
            audPlayer.clip = sounds[1];
            audPlayer.Play();
        }
        if (collision.gameObject.name == "PowerUp-enlarge")
        {
           
            Destroy(collision.gameObject);
            if (currentPaddle < paddleList.Length - 1)
            {
                transform.Find(paddleList[currentPaddle]).gameObject.SetActive(false);
                currentPaddle++;
                transform.Find(paddleList[currentPaddle]).gameObject.SetActive(true);
                gunHolder = transform.Find("GunHolder").GetComponent<GunHolder>();
            }

        }
        else if (collision.gameObject.name == "PowerUp-shrink")
        {
            Destroy(collision.gameObject);
            if (currentPaddle > 1)
            {
                transform.Find(paddleList[currentPaddle]).gameObject.SetActive(false);
                currentPaddle--;
                transform.Find(paddleList[currentPaddle]).gameObject.SetActive(true);
                gunHolder = transform.Find("GunHolder").GetComponent<GunHolder>();
            }

            score.GetComponent<score>().gameScore += 5;

        }
        else if (collision.gameObject.name == "PowerUp-split")

        {
            Destroy(collision.gameObject);
            ball = GameObject.Find("Ball");
            Debug.Log(GameManager.instance.currentBalls);

            if (true)
            {
                Debug.Log("passed");
                ballClone = Instantiate(ballPrefab, ball.transform.position, Quaternion.identity);
                ballClone.transform.GetComponent<ballz>().ballInPlay = true;
                ballClone.gameObject.name = "Ball";
                Rigidbody ballCloneRb = ballClone.GetComponent<Rigidbody>();
                ballCloneRb.isKinematic = false;
                Vector3 newVelocity = ball.GetComponent<Rigidbody>().velocity;
                newVelocity.x *= -1;
                ballCloneRb.velocity = newVelocity;
                GameManager.instance.currentBalls++;

                if (firebalActive) {
                    fireEff = ballClone.transform.Find("fx_fire_a");
                    fireEff.gameObject.SetActive(true);
                    ballClone.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
                    ballClone.GetComponent<ballz>().damage = 5;
                }

            }




        }
        else if (collision.gameObject.name == "PowerUp-fireball")
        {
            Destroy(collision.gameObject);
            firebalActive = true;
            foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
            {
                
                fireEff = ball.transform.Find("fx_fire_a");
                fireEff.gameObject.SetActive(true);
                ball.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
                ball.GetComponent<ballz>().damage = 5;

            }
            score.GetComponent<score>().gameScore += 5;
            //ball = GameObject.Find("Ball");
            //make the ball fireball
           
        }
        else if (collision.gameObject.name == "PowerUp-ballSpeed")
        {

            Destroy(collision.gameObject);

            foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
            {
                ball.GetComponent<ballz>().ballSpeed = 230;

            }
        }
        else if (collision.gameObject.name == "PowerUp-life")
        {
            Destroy(collision.gameObject);
            GameManager.instance.GetLife();
        }  else if (collision.gameObject.name == "PowerUp-death")
        {
            Destroy(collision.gameObject);
            GameManager.instance.LoseLife();
        }

        else if (collision.gameObject.name == "PowerUp-Gun")
       
        {
            Destroy(collision.gameObject);
            gunActive = true;
            transform.Find("GunHolder").gameObject.SetActive(true);
        }
    }
    public void TurnOffPowerup(){
        gunHolder.gameObject.SetActive(false);
        gunActive = false;
    }

}
