using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class letter : MonoBehaviour {

    public GameObject gameManager;
    public GameObject score;
    public GameObject ball;

    public Color matColor;

    public int letterType = 0;

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
     
        hasPowerUp = Random.value;
        powerUpType = Random.value;
      
        pwrUpPrefabs = gameManager.GetComponent<GameManager>().powerUpPrefabs;


        // Update is called once per frame
    }
	void Update () {
       
	}
    public void takeDamage(int damage){
        if(!GameManager.instance.gameOver){
            if (health <= 0)
            {
                gameObject.SetActive(false);
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
            }
            else if (health == 1)
            {
                rend.material.color = new Color(0.7647059f, 0.1549929f, 0.2726027f, 1f);
            }
            else if (health == 2)
            {
                rend.material.color = new Color(0.3f, 0.3f, 0.3f, 255f);
            }
            else if (health == 3)
            {

                rend.material.color = new Color(0.7215686f, 0.7215686f, 0.7215686f, 255f);
            }
            health -= damage;
        }

       
       
  
    }
}
