using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rend : MonoBehaviour {
	public Texture2D heightmap;
    public float height = 1;

    [SerializeField]
    private GameObject cubePrefab;

	// Use this for initialization
	void Start () {
		Color[] pixels = heightmap.GetPixels(0, 0, heightmap.width, heightmap.height);

		for(int x = 0; x < heightmap.height; x++){
			for (int y = 0; y < heightmap.width; y++){
			Debug.Log(x);
				Color color = pixels[(x * heightmap.width)+y ];

				
				if (color.a>0){
                    Instantiate(cubePrefab, new Vector3(-y, 0f, -x), Quaternion.identity, gameObject.transform);
                    //obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //obj.transform.parent = gameObject.transform;
					//obj.transform.position = new Vector3(-x, 0f ,y);
					//obj.AddComponent<Rigidbody>();
					//obj.GetComponent<Renderer>().material.color = Color.black;
				}

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
