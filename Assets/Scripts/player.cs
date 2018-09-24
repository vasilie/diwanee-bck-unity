using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    private float actualDistance;
    public GameObject score;

    public GameObject fireEff;
    [SerializeField]
    //private float speed = 1.0f;
    private Vector3 playerPos;
    float xPos;
    private float paddleSize;

    private Vector3 linearDistanceVector;
    private Vector3 mousePosition;

    public GameObject ball;
    public GameObject ballPrefab;

    private Transform paddle;
    private Vector3 finalPosition;
    private Camera cam;

    private GameObject ballClone;

    private int maxBalls = 2;
    private int currentBalls = 1;
    // Use this for initialization
    void Start () {
        cam = Camera.main;

       

        Vector3 finalPosition = new Vector3();
        Vector3 toObjectVector = new Vector3();

        toObjectVector = transform.position - cam.transform.position;
        linearDistanceVector = Vector3.Project(toObjectVector, cam.transform.forward);
        actualDistance = linearDistanceVector.magnitude;

        playerPos = gameObject.transform.position;
        xPos = playerPos.x;
        paddle = transform.Find("Paddle");
        paddleSize = paddle.transform.localScale.x;
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    void Update () {

       
        mousePosition = Input.mousePosition;
        mousePosition.z = actualDistance;
        //mousePosition.x = Mathf.Clamp(mousePosition.x, -154.0f, 58f);
        finalPosition = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mousePosition.z));
        finalPosition.z = 91.9f;
        finalPosition.y = 2.2f;
        transform.position = finalPosition;
        //xPos = - Input.mousePosition.x;
        //Debug.Log(xPos);
        //xPos = Mathf.Clamp(xPos, -154.0f, 58f);

        //playerPos = new Vector3(xPos, gameObject.transform.position.y, gameObject.transform.position.z);
        //transform.position = playerPos;


    }
    void OnCollisionEnter(Collision collision){
        Debug.Log(collision);
        if (collision.gameObject.name == "PowerUp-enlarge"){
            paddleSize += 0.1f;
            paddle.localScale = new Vector3(paddleSize, paddle.transform.localScale.y, paddle.transform.localScale.z);
            score.GetComponent<score>().gameScore += 5;

        }
        if (collision.gameObject.name == "PowerUp-split")
        {
            Destroy(collision.gameObject);
            if (maxBalls > currentBalls){
                ballClone = Instantiate(ballPrefab, ball.transform.position, Quaternion.identity);
                Rigidbody ballCloneRb = ballClone.GetComponent<Rigidbody>();
                ballCloneRb.isKinematic = false;
                ballCloneRb.velocity = ball.GetComponent<Rigidbody>().velocity;
                currentBalls++;
                maxBalls++;
            }

            Debug.Log(ball.GetComponent<Rigidbody>().velocity);
            Debug.Log(ballClone.GetComponent<Rigidbody>().velocity);


        }
        if (collision.gameObject.name == "PowerUp-fireball"){
            //make the ball fireball
            fireEff.SetActive(true);
            ball.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
            ball.GetComponent<ballz>().damage = 5;
            score.GetComponent<score>().gameScore += 5;
        }
        if (collision.gameObject.name == "PowerUp-shrink")
        {
            paddleSize -= 0.1f;
            paddle.localScale = new Vector3(paddleSize, paddle.transform.localScale.y, paddle.transform.localScale.z);
            score.GetComponent<score>().gameScore += 5;

        }

    }
}
