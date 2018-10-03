using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject bulletPrefab;
	// Use this for initialization
	void Start () {
		
	}
    public void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
