using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour {

    public int gameScore;

    public Text scoreText;
	// Use this for initialization
	void Start () {
        gameScore = 0;	
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "SCORE : " + gameScore.ToString();
	}
}
