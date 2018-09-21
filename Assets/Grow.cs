using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour {
    private Vector3 objFinalScale;

    public float growSize = 0.01f;
	// Use this for initialization
	void Start () {
        objFinalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        objFinalScale.x+=growSize;
        transform.localScale = objFinalScale;
	}
}
