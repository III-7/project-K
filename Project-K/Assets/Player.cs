using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Player : MonoBehaviour {
	UnityEvent keyEvent;//is invoked when a key is pressed, right now just calls movement, later will call a higher level function 
	float speed = 0.4f;//multiplier for number of units a player can move per frame
	float targetSpeed;//help for acceleration, not implemented correctly yet
	float t = 0.6f;//lerping multiplier
	Cam cam; //fps camera that follows the player, rotates with mouse, is child of player object
	float sensitivityMultiplier = 4.0f;//mouse sensitivity
	Vector3 camF = new Vector3();
	Vector3 camR = new Vector3();
	// Use this for initialization
	void Start () {
		cam = transform.GetComponentInChildren<Cam> ();
		//cam  = FindObjectOfType<Camera> ();
		camF = cam.transform.forward.normalized;
		camR = cam.transform.right.normalized;
		camF.y = 0;
		camR.y = 0;

		targetSpeed = this.speed;
		if (keyEvent == null) {
			keyEvent = new UnityEvent ();
		}
		keyEvent.AddListener (keyPress);
	}
	
	// Update is called once per frame
	void Update () {
		updateCam ();
		camF = cam.transform.forward.normalized;
		camR = cam.transform.right.normalized;
		camF.y = 0;
		camR.y = 0;
		Vector2 input = new Vector2 (Input.GetAxis ("Horizontal") * speed, Input.GetAxis ("Vertical") * speed);
		transform.position += (camF * input.y + camR * input.x);
	
		//this.transform.rotation = cam.transform.rotation;
		if (Input.anyKey && keyEvent != null) {
			keyEvent.Invoke ();
		}
	
	}
	void updateCam(){
		cam.transform.SetPositionAndRotation (new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z + 0.2f), Quaternion.identity);
		cam.transform.eulerAngles = new Vector3(cam.yRotate * sensitivityMultiplier, cam.xRotate * sensitivityMultiplier, 0.0f);
	}
	void keyPress(){
		
	}
}
