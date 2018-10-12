using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {

    public int life;

    private GameObject gameOverText;

    public GameObject lifePrefab;
	// Use this for initialization
	void Start () {
        life = 3;
        DrawLife();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoseLife(){
        life--;
        DrawLife();
        if (life < 0)
        {
            GameManager.instance.GameOver();

            gameOverText = GameManager.instance.gameOverText;
            gameOverText.SetActive(true);

        }
    }
    public void DrawLife(){
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        for (int i = 0; i < life; i++)
        {
            float xPos = i * (-40f);
            GameObject lifeObj = Instantiate(lifePrefab, new Vector3(xPos, 0f, 0f), Quaternion.identity);
            lifeObj.transform.SetParent(transform, false);
           
        }
    }
}
