using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	public float smooth = 2.0f;
	public float tiltAngle = 40.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float max = 0.0f;
		float tiltAroundZ = Input.GetAxis ("Vertical") * tiltAngle;

		if (max < tiltAroundZ) {
			max = tiltAroundZ;
		} 
		else {
			//max = tiltAroundZ;
		}
		Debug.Log(max + ", "+ tiltAroundZ);
		Quaternion target = Quaternion.Euler (0, 0, max);
		transform.rotation = Quaternion.Slerp (transform.rotation,target,Time.deltaTime * smooth);
	}
}
