using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class letter : MonoBehaviour {

    public GameObject gameManager;
    public GameObject score;
    public GameObject ball;

    private AudioSource player;
    private AudioClip[] sounds;

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
        health = 3;
        hasPowerUp = Random.value;
        powerUpType = Random.value;
        pwrUpPrefabs = gameManager.GetComponent<GameManager>().powerUpPrefabs;


        // Update is called once per frame
    }
	void Update () {
        if (health <= 0){
            Destroy(gameObject);
            CameraShaker.Instance.ShakeOnce(0.7f, 4f, 0.1f, 1f);
            score.GetComponent<score>().gameScore+=10;
            GameManager.instance.DestroyLetter();
            if (hasPowerUp >0){
                
                if(powerUpType <0.1){
                    powerUpObj = Instantiate(pwrUpPrefabs[0], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-enlarge";

                } else if (powerUpType < 0.2){
                    powerUpObj = Instantiate(pwrUpPrefabs[1], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-fireball";

                } else if (powerUpType < 0.3){
                    powerUpObj = Instantiate(pwrUpPrefabs[2], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-shrink";
                } else if (powerUpType <0.4){
                    powerUpObj = Instantiate(pwrUpPrefabs[3], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-gun";
                } else if (powerUpType < 0.5){

                    powerUpObj = Instantiate(pwrUpPrefabs[4], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-paddleSpeed";
                }
                else if (powerUpType < 0.6){
                    powerUpObj = Instantiate(pwrUpPrefabs[5], transform.position, Quaternion.identity);
                    powerUpObj.name = "PowerUp-ballSpeed";
                }

            }
        }
        if (health ==1) {
            rend.material.color = Color.red;
        }
        if (health == 2)
        {
            rend.material.color = new Color(0.2f, 0.2f, 0.2f, 255f);
        }
        if (gameManager.GetComponent<GameManager>().gameOver){
            GetComponent<MeshCollider>().convex = true;
            rb.isKinematic = false;
            rb.useGravity = true;
        }
	}
}
