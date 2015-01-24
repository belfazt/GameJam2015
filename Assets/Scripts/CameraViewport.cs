using UnityEngine;
using System.Collections;

public class CameraViewport : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Jump")){
            float margin = Random.Range(0.0f, 0.3f);
            camera.rect = new Rect(margin, 0, 1 - margin * 2, 1);
        }
	}
}
