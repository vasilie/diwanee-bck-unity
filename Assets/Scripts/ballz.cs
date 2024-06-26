﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ballz : MonoBehaviour {
    public float ballSpeed;

    public float initialBallSpeed = 200f;

    public AudioClip[] sounds;
    private AudioSource player;

    public GameObject gameOverText;
    public GameObject letterParticles;
    public GameObject ply;
   
    public GameObject gameManager;
    public int damage;

    private Rigidbody rb;

    public bool ballInPlay;
	// Use this for initialization
	void Awake () {


       
        damage = 1;
        rb = GetComponent<Rigidbody>();
        player = GetComponent<AudioSource>();
	}
	private void Start()
	{
        ballSpeed = initialBallSpeed * 100f;
       
	}
	// Update is called once per frame
	void Update () {
        if (ply == null && GameManager.instance.gameStarted){
            ply = GameObject.Find("Player");
        }
        if(Input.GetButtonDown("Fire1") && ballInPlay == false ){
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(0, 0, -ballSpeed));

        }
        if (!ballInPlay && GameManager.instance.gameStarted)
        {
            Vector3 newPosition = ply.transform.position;
            newPosition.z = ply.transform.position.z - 1.4f;
            transform.position = newPosition;
        }
       
	}
	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag == "Letter"){
            if (!GameManager.instance.gameOver){
                collision.transform.GetComponent<letter>().takeDamage(damage);
            }
            ContactPoint contact = collision.contacts[0];
            //adaDestroy(collision.gameObject);
            Vector3 particlePos = contact.point;
            particlePos.y += 10f;
            Instantiate(letterParticles, particlePos, Quaternion.identity);
            player.clip = sounds[0];
            player.Play();


        }
        if (collision.gameObject.name == "Player"){
            player.clip = sounds[3];
            player.Play();
           
        }
        if (collision.gameObject.name == "Bound")
        {
            player.clip = sounds[1];
            player.Play();

        }
        if (collision.gameObject.name == "end" ){
            if (GameManager.instance.currentBalls > 1) {
                Destroy(gameObject);
                GameManager.instance.currentBalls--;
                CameraShaker.Instance.ShakeOnce(3f, 4f, 0.1f, 1f);
                GameManager.instance.FindBall();

            } else {
                CameraShaker.Instance.ShakeOnce(3f, 4f, 0.1f, 1f);
                GameManager.instance.LoseLife();
                    
                if (!GameManager.instance.gameOver)
                {
                    ResetBall();
                    GameManager.instance.ResetPlayerBuffs();
                }

            }
           
        }

	}
    public void ResetBall(){
        ballInPlay = false;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        //gameObject.transform.localScale = new Vector3(0.06578948÷f, 0.3571429f, 1.041667f);
        transform.localScale = new Vector3(3f, 3f, 3f);

        Vector3 newPosition = ply.transform.position;
        transform.position = newPosition;
        newPosition.z = ply.transform.position.z -3f;
        transform.Find("fx_fire_a").gameObject.SetActive(false);
        //transform.SetParent(ballHolder, false);
        transform.position = newPosition;
        ballSpeed = initialBallSpeed * 100f;
       

        damage = 1;

    }
   
	void FixedUpdate(){
       
     
        if (Time.frameCount % 100 == 1 && ballInPlay)
        {
            ballSpeed += 30;


        }
        rb.velocity = ballSpeed / 2.5f * (rb.velocity.normalized) * Time.deltaTime;

        //rb.velocity = 56f * ballSpeed * (rb.velocity.normalized) * Time.deltaTime;

    }
}
