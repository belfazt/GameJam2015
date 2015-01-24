using UnityEngine;
using System.Collections;

public class GUIBehaviour : MonoBehaviour {
    public GUIStyle myGUI;
    public GUISkin skin;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        GUI.Label(new Rect(0, 0, Screen.width / 4, Screen.height / 10), "Lives Remaining: " + player.GetComponent<PlayerController>().getLives(), myGUI);
    }
}
