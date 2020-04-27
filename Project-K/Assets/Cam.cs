using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {
	public float xRotate = 0f;
	public float yRotate = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		xRotate += Input.GetAxis ("Mouse X");
		yRotate -= Input.GetAxis ("Mouse Y");
	}

}
