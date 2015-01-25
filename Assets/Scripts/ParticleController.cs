using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        particleSystem.Pause();
	}
	
	// Update is called once per frame
	void Update () {
	        
	}

    public void particlesPlay(float secs) {
        StartCoroutine(playShortFall(secs));
    }

    IEnumerator playShortFall(float secs) {
        particleSystem.Play();
        yield return new WaitForSeconds(secs);
        particleSystem.Pause();
    }

}
