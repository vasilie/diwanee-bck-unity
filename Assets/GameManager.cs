using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] powerUpPrefabs;
    public bool isStarted;
    public bool gameOver;

    public AudioClip[] sounds;
    private AudioSource player;

    public GameObject ball;

    public GameObject letterHolder;

    private int lettersLeft;

    public static GameManager instance = null;

	// Use this for initialization
	void Start () {
        player = GetComponent<AudioSource>();
        if (instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        lettersLeft = letterHolder.transform.childCount;
        gameOver = false;

    }

    public void DestroyLetter(){
        lettersLeft--;
        player.clip = sounds[0];
        player.Play();
    }
    public void Setup(){
        
    }

	// Update is called once per frame
	void Update () {
        if (!isStarted && Input.GetKey("space")){
            isStarted = true;
        }

    }
}
