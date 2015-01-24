using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
    public string axis;
    public float speed ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis(axis);
        
        transform.Rotate(Vector3.back, Time.deltaTime * speed * h, Space.World);
	}
}
