using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    private float actualDistance;
    public GameObject score;


    [SerializeField]
    //private float speed = 1.0f;
    private Vector3 playerPos;
    float xPos;
    private float paddleSize = 0.016f;

    private Vector3 linearDistanceVector;
    private Vector3 mousePosition;

    public GameObject ball;

    private Transform paddle;
    private Vector3 finalPosition;
    private Camera cam;
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

        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKey("left")){
        //    xPos += speed;

        //}
        //if (Input.GetKey("right")){
        //    xPos -= speed;
        //}
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
            paddleSize += 0.002f;
            paddle.localScale = new Vector3(paddleSize, paddle.transform.localScale.y, paddle.transform.localScale.z);
            score.GetComponent<score>().gameScore += 5;

        }
        if (collision.gameObject.name == "PowerUp-fireball"){
            //make the ball fireball
            ball.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
            ball.GetComponent<ballz>().damage = 5;
            score.GetComponent<score>().gameScore += 5;
        }
        if (collision.gameObject.name == "PowerUp-shrink")
        {
            paddleSize -= 0.002f;
            paddle.localScale = new Vector3(paddleSize, paddle.transform.localScale.y, paddle.transform.localScale.z);
            score.GetComponent<score>().gameScore += 5;

        }

    }
}
