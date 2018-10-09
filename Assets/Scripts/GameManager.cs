using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;

    public GameObject ply;

    public GameObject[] powerUpPrefabs;
    public bool isStarted;
    public bool gameOver;

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
	// Use this for initialization
	private void Awake()
	{
        FindBall();
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
        if (lettersLeft <= 0){
            gameOver = true;
            gameWinText.gameObject.SetActive(true);
        }
    }
    public void Setup()
    {

    }
    public void ReloadLevel()
    {
        if (gameOver){
            Application.LoadLevel(Application.loadedLevel);
        }
      
    }
    public GameObject FindBall(){
        ball = GameObject.Find("Ball");
        return ball;
    }
    public void GetLife(){
        lifeManager.GetComponent<LifeManager>().life++;
        lifeManager.GetComponent<LifeManager>().DrawLife();
    }
    //public void FindLetters(){
    //    for (int i = 0; i < letterHolder.transform.childCount; i++)
    //    {
    //        letterTransforms[i] = letterHolder.FindChild(i).transform;
    //    }
    //}
    //public void ResetLetters(){
        
    //}
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
    }
    public void StartGame(){
        gameStarted = true;
        ball.SetActive(true);
        ply.SetActive(true);
    }
}
