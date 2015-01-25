using UnityEngine;
using System.Collections;

public class GUIBehaviour : MonoBehaviour {
    public GUIStyle myGUI;
    public GUIStyle bigLetters;
    public GUISkin skin;
    private GameObject player;
    private int timer;
    private bool verifSecs;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        timer = -1;
        this.verifSecs = true;
        StartCoroutine(Timer());
	}

    IEnumerator Timer() {
        while (true) {
            try{
                if (player.GetComponent<PlayerController>().getSecondsToStart() <= 0){
                    timer += (1 * (int)Time.timeScale);
                }
            }
            catch (MissingReferenceException e){
                Debug.Log(e);
                break;
            }
            yield return new WaitForSeconds(1);
        }
    }
	// Update is called once per frame
	void Update () {
	    
	}

    void OnGUI() {
        try{
            GUI.Label(new Rect(Screen.width/8, Screen.height/8, Screen.width / 4, Screen.height / 10), "" + Information.lives, myGUI);
            GUI.Label(new Rect(Screen.width/8, 9*Screen.height / 10, Screen.width / 4, Screen.height / 10), ""+timer, myGUI);
            GUI.Label(new Rect(7*Screen.width / 8, Screen.height / 8, Screen.width / 4, Screen.height / 10), "" + Information.points, myGUI);
            if (this.verifSecs){
                if (player.GetComponent<PlayerController>().getSecondsToStart() > 0){
                    GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 300, 200, 600), " " + player.GetComponent<PlayerController>().getSecondsToStart(), bigLetters);
                }
            }
            else {
                this.verifSecs = false;
            }
        }
        catch (MissingReferenceException e){

            Debug.Log(e);
        }
        
    }
}
