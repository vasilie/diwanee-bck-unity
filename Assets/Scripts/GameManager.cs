using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;

    public GameObject ply;
    public GameObject clickHere;
    public GameObject score;
    public GameObject announcements;

    public GameObject[] powerUpPrefabs;
    public bool isStarted;
    public bool gameOver;
    public bool gameWin;
    public int currentLevel = 1;

    public AudioClip[] sounds;
    private AudioSource player;

    private Transform[] letterTransforms;

    public GameObject ball;
    public int currentBalls = 1;

    public GameObject letterHolder;
    private int lettersLeft;

    public static GameManager instance = null;

    public GameObject lifeManager;

    public GameObject gameOverText;
    public GameObject gameWinText;
    public GameObject currentLevelText;


	// Use this for initialization
	private void Awake()
	{
        Cursor.visible = true;
        gameWin = false;
	}
	void Start()
    {
        
        player = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        lettersLeft = letterHolder.transform.childCount;
        gameOver = false;
       

    }

    public void DestroyLetter()
    {
        lettersLeft--;
        player.clip = sounds[3];
        player.Play();
        if (lettersLeft <= 0 && currentLevel == 1){
            letterHolder.GetComponent<Animator>().SetBool("disableMeshRend", true);
            FindBall();
            foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
            {

                ball.GetComponent<Rigidbody>().isKinematic = true;
            }
            announcements.GetComponent<Animator>().SetInteger("level", 2);
            currentLevelText.GetComponent<Text>().text = "lvl 02";
        } else if (lettersLeft <=0 && currentLevel == 2 ){
            gameWinText.SetActive(true);
            gameWin = true;
            Debug.Log(gameWin);
            foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
            {

                ball.GetComponent<Rigidbody>().isKinematic = true;
               
            }
        }

    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
    public GameObject FindBall(){
        ball = GameObject.Find("Ball");
        return ball;
    }
    public void GetLife(){
        if (lifeManager.GetComponent<LifeManager>().life <3){
            lifeManager.GetComponent<LifeManager>().life++;
            lifeManager.GetComponent<LifeManager>().DrawLife();
        }

    }
    public void LetterHit(){
        player.clip = sounds[2];
        player.Play();
    }

    public void LoseLife()
    {
        lifeManager.GetComponent<LifeManager>().LoseLife();
    }
	// Update is called once per frame
	void Update () {
        
        if (!isStarted && Input.GetKey("space")){
            isStarted = true;
        }
        if (Input.GetKeyDown("space") && gameOver){
            ReloadLevel();   
        }
        if (Input.GetKeyDown("space") && gameWin){
            ReloadLevel();
            Debug.Log("game is won matori");
        }
    }
    public void StartGame(){
        gameStarted = true;
        //FindBall();
        ball.SetActive(true);
        ply.SetActive(true);
        lifeManager.SetActive(true);
        clickHere.SetActive(false);
        score.SetActive(true);
        currentLevelText.SetActive(true);
        Cursor.visible = false;

    }
    public void GameOver(){
        gameOver = true;
        letterHolder.GetComponent<Animator>().enabled = false;
        foreach (GameObject letter in GameObject.FindGameObjectsWithTag("Letter"))
        {
            Rigidbody rb = letter.GetComponent<Rigidbody>();
            letter.GetComponent<MeshCollider>().convex = true;

            rb.isKinematic = false;
            rb.useGravity = true;

        }
       
    }
    public void StartNewLevel(int level){
       
      
        if (level == 2){
            foreach (GameObject letter in GameObject.FindGameObjectsWithTag("Letter"))
            {
                letter.SetActive(true);

            }
           
            letterHolder.GetComponent<Animator>().SetInteger("level", 2);
            FindBall();
            foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
            {
                ball.GetComponent<ballz>().ResetBall();

            }
           
            currentLevel = 2;
        }
        lettersLeft = letterHolder.transform.childCount;
    }
    public void EnableLetters(){
        letter[] trs = letterHolder.GetComponentsInChildren<letter>(true);
        foreach (letter t in trs)
        {
            t.health = 4;


            t.GetComponent<Renderer>().material.color = t.GetComponent<letter>().matColor;
            t.gameObject.SetActive(true);
        }
    }
    public void ResetPlayerBuffs()
    {
        //player set fire eff 
        ply.GetComponent<player>().firebalActive = false;
        ply.GetComponent<player>().TurnOffPowerup();
    }
}
