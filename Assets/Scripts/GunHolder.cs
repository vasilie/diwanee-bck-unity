using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour {

    public GameObject gun1;
    public GameObject gun2;
    // Use this for initialization
    private Gun Gun1;
    private Gun Gun2;

	private void Start()
	{
        Gun1 = gun1.GetComponent<Gun>();
        Gun2 = gun2.GetComponent<Gun>();
	}
	public void Shoot(){
        
        if (Gun1 != null){
            Gun1.Shoot();
            Gun2.Shoot();  
        }

    }
	// Update is called once per frame
	
}
