using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float jumpForce;
    public int lives;
    private bool ableToJump;
    private bool grounded;
	// Use this for initialization
	void Start () {
        this.ableToJump = true;
        this.grounded = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.Translate(new Vector3(/*Input.GetAxis("Horizontal")*/1, 0, 0) * Time.deltaTime * speed, Space.World);
		transform.Translate(0.10F, 0, 0 * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && ableToJump && grounded){
            rigidbody.AddForce(new Vector3(0, jumpForce, 0));
            ableToJump = false;
            grounded = false;
            StartCoroutine(TouchGround(1.5f));
        }

	}

	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.tag == "Trigger"){
			Destroy(gameObject);
		} 
	}
    IEnumerator TouchGround(float secs) {
        yield return new WaitForSeconds(secs);
        this.ableToJump = true;
    }

    public int getLives() {
        return this.lives;
    }

    void OnCollisionEnter(Collision c) {
        if (c.transform.tag.Equals("Platform")) {
            
            this.grounded = true;
        }
    }
}
