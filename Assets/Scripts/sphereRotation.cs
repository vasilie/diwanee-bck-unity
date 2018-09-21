using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereRotation : MonoBehaviour {

    private float Rotation;
    private float axis;

    private float speed;
    private float direction;
	// Use this for initialization
	void Start () {
        direction = Random.value > 0.5 ? -1 : 1;
        axis = Random.value;
        speed = Random.value * 2f + 1;
	}

    // Update is called once per frame
    void Update()
    {
        Rotation += speed * direction;
        if (axis > 0.33f)
        {
            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, Rotation, transform.rotation.eulerAngles.z);
        }
        else if (axis > 0.66f)
        {
            transform.eulerAngles = new Vector3(Rotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Rotation);
        }
    }
}
