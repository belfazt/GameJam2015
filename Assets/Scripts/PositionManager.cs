using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PositionManager : MonoBehaviour {
    
    public GameObject[] cameras;
    public float smooth;
    private Transform[] positionPool;
	// Use this for initialization
	void Start () {
        prepareArray();   
    }

    void prepareArray() {
        int[] randomPositions  = pseudoRandomNumberGenerator();
        //Debug.Log(randomPositions);
        positionPool = new Transform[cameras.Length];
        for (int i = 0; i < cameras.Length; i++) {
            positionPool[i] = (cameras[randomPositions[i]-1].transform);
        }
        
    }

    int[] pseudoRandomNumberGenerator() {
        int[] array = new int[cameras.Length];
        for (int i = 0; i < array.Length; i++) {
            array[i] = i + 1;    
        }
        for (int i = cameras.Length - 1; i > 1; i--) {
            int j = Random.Range(0, i);
            int helper;
            helper = array[i];
            array[i] = array[j];
            array[j] = helper;
        }
        /*string a = "";
        for (int i = 0; i < cameras.Length; i++) {
            a += array[i] + " ";
        }
        a += "\n";
        Debug.Log(a);
         */
        return array;
    }
	// Update is called once per frame
	void Update () {
       
	}

    public Vector3 getNewPosition(int p) {
        return this.positionPool[p].position;
    }
}
