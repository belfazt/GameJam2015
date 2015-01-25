using UnityEngine;
using System.Collections;

public class puntos : MonoBehaviour {
	public float score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
 void OnCollisionEnter (Collision bola ) 
	{ 
		if (bola.transform.tag.Equals ("bola"))
		score = score + 1;
	}
}
	