using UnityEngine;
using System.Collections;

public class GUIBehaviour : MonoBehaviour {
    public GUIStyle myGUI;
    public GUIStyle bigLetters;
    public GUISkin skin;
    private GameObject player;
    private int timer;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        timer = 0;
        StartCoroutine(Timer());
	}

    IEnumerator Timer() {
        while (true) {
            if (player.GetComponent<PlayerController>().getSecondsToStart() <= 0){
                timer += (1 * (int)Time.timeScale);
            }
            
            yield return new WaitForSeconds(1);
        }
    }
	// Update is called once per frame
	void Update () {
	    
	}

    void OnGUI() {
        try{
            GUI.Label(new Rect(0, 0, Screen.width / 4, Screen.height / 10), "Lives Remaining: " + player.GetComponent<PlayerController>().getLives(), myGUI);
            GUI.Label(new Rect(0, Screen.height / 10, Screen.width / 4, Screen.height / 10), "Time playing like\n a n00b: " + timer, myGUI);
            if (player.GetComponent<PlayerController>().getSecondsToStart() > 0)
            {
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 300, 200, 600), "" + player.GetComponent<PlayerController>().getSecondsToStart(), bigLetters);
            }
        }
        catch (MissingReferenceException e){

            //Debug.Log(e);
        }
        
    }
}
