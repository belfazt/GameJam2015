using UnityEngine;
using System.Collections;

public class LevelChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c) {
        if (c.transform.name.Equals("Player")) {
            Application.LoadLevel(Application.loadedLevel+1);
        }
    }
}
