using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
    bool running;
	// Use this for initialization
	void Start () {
        this.running = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")) {
            animation.Play("jump");
        }
        else if (running)
        {
            animation.Play("run");
        }
        else {
            animation.PlayQueued("idle");
        }
	}
}
