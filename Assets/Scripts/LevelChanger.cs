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

    void OnTriggerEnter(Collider c) {
        if (c.transform.name.Equals("Player")) {
            Application.LoadLevel(Application.loadedLevel+1);
        }
    }

    public void MenuClick() {
        Application.LoadLevel(Application.loadedLevel+1);
    }

    public void OpenCredits() {
        Application.OpenURL("http://globalgamejam.org/2015/games/pixel-paradox");
    }
}
