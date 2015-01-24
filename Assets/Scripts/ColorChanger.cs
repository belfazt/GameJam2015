using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {
    public Color toPaint;
	// Use this for initialization
	void Start () {
        transform.renderer.material.color = toPaint;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
