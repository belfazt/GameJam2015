using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    public float smooth;
    private Vector3 movement;
    public GameObject manager;
    
    private int cameraNum;
    void Awake() {
        cameraNum = int.Parse(transform.name.Split(' ')[1]);
        cameraNum--;
        StartCoroutine(GetMovement());
    }

    IEnumerator GetMovement() {
        while (movement.Equals(new Vector3(0, 0, 0))) {
            yield return new WaitForSeconds(3);
            movement = manager.GetComponent<PositionManager>().getNewPosition(this.cameraNum);
            if (!movement.Equals(new Vector3(0, 0, 0))) {
                break;
            }
            Debug.Log(movement);
            //StopCoroutine(GetMovement());
        }
    }
	// Use this for initialization
	void Start () {
        this.smooth = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (!movement.Equals(new Vector3(0, 0, 0))){
            PositionChanging();

        }
	}

    void PositionChanging() {
        
        //Debug.Log(movement);
        transform.position = Vector3.Lerp(transform.position, movement, smooth * Time.deltaTime);
        
    }
}
