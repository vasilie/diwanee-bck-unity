using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ballz : MonoBehaviour {
    public float ballSpeed = 100f;

    public AudioClip[] sounds;
    private AudioSource player;

    public GameObject letterParticles;
    public GameObject ply;
    public GameObject lifeManager;
    public GameObject gameManager;
    public int damage;

    private Rigidbody rb;

    private bool ballInPlay;
	// Use this for initialization
	void Awake () {
        damage = 1;
        rb = GetComponent<Rigidbody>();
        player = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1") && ballInPlay == false ){
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(-ballSpeed, 0, -ballSpeed));
        }
        if (Time.frameCount % 100 == 0){
            ballSpeed += 1;
        }
	}
	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.name == "Letter"){
            collision.transform.GetComponent<letter>().health -= damage;
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
           
            lifeManager.GetComponent<LifeManager>().life--;
            lifeManager.GetComponent<LifeManager>().DrawLife();
             
           
            if (lifeManager.GetComponent<LifeManager>().life < 0){
                GameManager.instance.gameOver = true;

            }
            if (!GameManager.instance.gameOver){
                ResetBall();
            }
            Debug.Log(lifeManager.GetComponent<LifeManager>().life);
        }

	}
    public void ResetBall(){
        ballInPlay = false;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.position = new Vector3(0.002192949f, 0.03571428f, -0.4513873f);
        gameObject.transform.localScale = new Vector3(0.06578948f, 0.3571429f, 1.041667f);
        gameObject.transform.SetParent(ply.transform, false);
    }
    void FixedUpdate(){
        rb.velocity = ballSpeed * (rb.velocity.normalized);
    }
}
