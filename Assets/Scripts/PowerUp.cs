using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private float posZ;

    public string type;
	// Use this for initialization
	void Start () {
        posZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        posZ++;
        transform.position = new Vector3(transform.position.x, 3.4f, posZ);
	}
}
