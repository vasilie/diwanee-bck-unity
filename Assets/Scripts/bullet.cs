using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {


    public GameObject letterParticles;

    private int damage = 1;
    private Vector3 position;
    public int speed;
	// Use this for initialization
	void Start () {
        position = transform.position;
	}
  
	// Update is called once per frame
	void Update () {
        position.z-=speed;
        transform.position = position;
	}
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.name == "Letter")
        {
            if (!GameManager.instance.gameOver)
            {
                collision.transform.GetComponent<letter>().takeDamage(damage);


            }
            ContactPoint contact = collision.contacts[0];
            GameManager.instance.LetterHit();
            //adaDestroy(collision.gameObject);
            Vector3 particlePos = contact.point;
            particlePos.y += 10f;
            Instantiate(letterParticles, particlePos, Quaternion.identity);
            //player.clip = sounds[0];
            //player.Play();

        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
