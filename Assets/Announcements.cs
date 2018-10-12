using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Announcements : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CallNewLevel(){
        //GameManager.instance.StartNewLevel(2);
        GameManager.instance.StartNewLevel(2);
    }
    public void EnableLetters()
    {
        GameManager.instance.EnableLetters();
    }
}
