using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour {

	// Use this for initialization
	public float speed;
	Vector3 position;
	float x = -9.0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x-=speed/100.0f;
		position = new Vector3(x, -18, 23);
		gameObject.transform.position = position;
	}
}
