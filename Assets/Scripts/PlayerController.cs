using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private float speed;
    public float jumpForce;
    
    private bool ableToJump;
    private bool grounded;
    private bool paused;
    private int secondsToStart;
	public float score=0;
    private bool jumped;
    //private ParticleController particleC;
	private Particle crush;
	public GameObject death;
    private LevelChanger lvlChg;
	public GameObject jump;
	// Use this for initialization
	void Start () {
        this.ableToJump = true;
        this.grounded = false;
        this.paused = false;
        this.secondsToStart = 6;
        this.speed = 0;
        lvlChg = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
        StartCoroutine(Countdown());

	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.Translate(new Vector3((1 + Input.GetAxis("Horizontal")/2), 0, 0) * Time.deltaTime * speed, Space.World);
        if (Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("Hello");
            Pause();
        }
        

	}
    void FixedUpdate()
    {       
        if (Input.GetButtonDown("Jump") && ableToJump && grounded)
        {
			print ("salto");
			Instantiate(jump,transform.position,Quaternion.identity);
            rigidbody.velocity = new Vector3(0, jumpForce, 0);
            ableToJump = false;
            grounded = false;
            StartCoroutine(TouchGround(0.5f));

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

			Instantiate(death,transform.position,Quaternion.identity);
            Information.lives--;
            lvlChg.ReloadLvl();
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
        return Information.lives;
    }

    public int getSecondsToStart() {
        return this.secondsToStart;
    }
    void OnCollisionEnter(Collision c){
        if (c.transform.tag.Equals("Platform")){
            if(!grounded && jumped){
                try
                {
                  //  particleC.particlesPlay(0.7f);
                }
                catch (MissingReferenceException e)
                {

                    //Debug.Log(e);
                }
                
            } 
            grounded = true;
            jumped = false;
              
        }
        if (c.gameObject.tag == "orb"){
            Debug.Log("gotta go fast");
        }
        if (c.gameObject.tag == "puntos"){
            Debug.Log("gotta catch'em all");
        }
    }
  
    void OnCollisionExit(Collision c) {
        if (c.transform.tag.Equals("Platform")) {
            jumped = true;
        }
        
    }
}
