using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float jumpForce;
    private bool ableToJump;
    private bool grounded;
	// Use this for initialization
	void Start () {
        this.ableToJump = true;
        this.grounded = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {

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

    void OnCollisionEnter(Collision c) {
        if (c.transform.tag.Equals("Platform")) {
            
            this.grounded = true;
        }
    }
}
