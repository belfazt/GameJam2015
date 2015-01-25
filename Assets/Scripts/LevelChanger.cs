using UnityEngine;
using System.Collections;

public class LevelChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Nivel Actual " +Application.loadedLevelName+", "+ Application.loadedLevel);
        Debug.Log("Nivel Siguiente: " + (Application.loadedLevel + 1 % Application.levelCount));
        if (Information.lives < 0){
            Application.LoadLevel(0);
        }
        if (Application.loadedLevel == 0) {
            Information.lives = 5;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c) {
        if (c.transform.name.Equals("Player")) {
            Application.LoadLevel(Application.loadedLevel + 1 % Application.levelCount);
        }
    }

    void OnTriggerEnter(Collider c) {
        if (c.transform.name.Equals("Player")) {
            Debug.Log(Application.loadedLevelName);

            Application.LoadLevel(Application.loadedLevel + 1 % Application.levelCount);
        }
    }

    public void MenuClick() {
        Application.LoadLevel(Application.loadedLevel + 1 % Application.levelCount);
    }

    public void OpenCredits() {
        Application.OpenURL("http://globalgamejam.org/2015/games/pixel-paradox");
    }

    public void ReloadLvl() {
        StartCoroutine(ReloadLevel());
    }
    
    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel(Application.loadedLevel);
    }
}
