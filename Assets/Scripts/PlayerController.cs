using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private float speed;
    public float jumpForce;
    public int lives;
    private bool ableToJump;
    private bool grounded;
    private bool paused;
    private int secondsToStart;
	// Use this for initialization
	void Start () {
        this.ableToJump = true;
        this.grounded = true;
        this.paused = false;
        this.secondsToStart = 6;
        this.speed = 0;
        StartCoroutine(Countdown());
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.Translate(new Vector3(/*Input.GetAxis("Horizontal")*/1, 0, 0) * Time.deltaTime  * speed, Space.World);

        if(Input.GetButtonDown("Jump") && ableToJump && grounded){
            rigidbody.AddForce(new Vector3(0, jumpForce, 0));
            ableToJump = false;
            grounded = false;
            StartCoroutine(TouchGround(1.5f));
        }
        else if (Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("Hello");
            Pause();
        }

	}

    void Pause() { 
        this.paused = !this.paused;
        if(paused){
            Time.timeScale = 0.0f;
        }  
        else {
            Time.timeScale = 1.0f;
        }
    }

	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.tag == "Trigger"){
            this.lives--;
            Destroy(gameObject);
		} 
	}
    IEnumerator TouchGround(float secs) {
        yield return new WaitForSeconds(secs);
        this.ableToJump = true;
    }

    IEnumerator Countdown() {
        while (this.secondsToStart-- > 0){
            yield return new WaitForSeconds(1);
        }
        this.speed = 3;
    }

    public int getLives() {
        return this.lives;
    }

    public int getSecondsToStart() {
        return this.secondsToStart;
    }

    void OnCollisionEnter(Collision c) {
        if (c.transform.tag.Equals("Platform")) {
            
            this.grounded = true;
        }
    }
}
