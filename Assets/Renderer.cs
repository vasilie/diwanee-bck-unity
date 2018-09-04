using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renderers : MonoBehaviour {
	public Texture2D heightmap;
	public float height = 1;
	// Use this for initialization
	void Start () {
		Color[] pixels = heightmap.GetPixels(0, 0, heightmap.width, heightmap.height);

		for(int x = 0; x < heightmap.width; x++){
			for (int y=0; y < heightmap.height; y++){
				Color color = pixels[(x * heightmap.width)+y];

				GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
				obj.transform.position = new Vector3(x, Mathf.Ceil(color.a),y);
				obj.GetComponent<Renderer>().material.color = color;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
