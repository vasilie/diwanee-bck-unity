using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataMenager : MonoBehaviour {
    public GameObject cube;
	// Use this for initialization
	void Start () {
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 1; x++)
            {
                Instantiate(cube, new Vector3(x, y+0.5f, 0), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
