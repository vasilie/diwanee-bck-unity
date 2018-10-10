﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class letter : MonoBehaviour {

    public GameObject gameManager;
    public GameObject score;
    public GameObject ball;


    public int health;
    private float hasPowerUp;
    public Renderer rend;

    private GameObject[] pwrUpPrefabs;

    public GameObject powerUp;
    public GameObject powerUpObj;
    public Rigidbody rb;
    private float powerUpType;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        //health = 3;
        hasPowerUp = Random.value;
        powerUpType = Random.value;
      
        pwrUpPrefabs = gameManager.GetComponent<GameManager>().powerUpPrefabs;


        // Update is called once per frame
    }
	void Update () {
       
        if (gameManager.GetComponent<GameManager>().gameOver){
            
            GetComponent<MeshCollider>().convex = true;
            rb.isKinematic = false;
            rb.useGravity = true;
        }
	}
    public void takeDamage(int damage){
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            CameraShaker.Instance.ShakeOnce(0.7f, 4f, 0.1f, 1f);
            score.GetComponent<score>().gameScore += 10;
            GameManager.instance.DestroyLetter();
            if (hasPowerUp >= 0.6)
            {

                if (powerUpType < 0.1)
                {
                    powerUpObj = Instantiate(pwrUpPrefabs[0], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-enlarge";

                }
                else if (powerUpType < 0.2)
                {
                    powerUpObj = Instantiate(pwrUpPrefabs[1], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-fireball";

                }
                else if (powerUpType < 0.3)
                {
                    powerUpObj = Instantiate(pwrUpPrefabs[2], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-shrink";
                }
                else if (powerUpType < 0.4)
                {
                    powerUpObj = Instantiate(pwrUpPrefabs[3], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-split";
                }
                else if (powerUpType < 0.5)
                {

                    powerUpObj = Instantiate(pwrUpPrefabs[4], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-life";
                }
                else if (powerUpType < 0.6)
                {
                    powerUpObj = Instantiate(pwrUpPrefabs[5], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-ballSpeed";
                }
                else if (powerUpType < 0.7)
                {
                    powerUpObj = Instantiate(pwrUpPrefabs[6], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-death";
                }
                else if (powerUpType < 0.8)
                {
                    powerUpObj = Instantiate(pwrUpPrefabs[7], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-Gun";
                }

            }
        } else if (health == 1){
            rend.material.color = new Color(0.8980392f, 0.1254902f, 0.2941177f, 1f);
        } else if (health == 2){
            rend.material.color = new Color(0.3f, 0.3f, 0.3f, 255f);
        }
  
    }
}
