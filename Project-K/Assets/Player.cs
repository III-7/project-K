using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Player : MonoBehaviour {
	UnityEvent keyEvent;//is invoked when a key is pressed, right now just calls movement, later will call a higher level function 
	float speed = 0.05f;//multiplier for number of units a player can move per frame
	float targetSpeed;//help for acceleration, not implemented correctly yet
	float t = 0.6f;//lerping multiplier
	Cam cam; //fps camera that follows the player, rotates with mouse, is child of player object
	float sensitivityMultiplier = 5.0f;//mouse sensitivity
	// Use this for initialization
	void Start () {
		//cam  = FindObjectOfType<Camera> ();
		cam = transform.GetComponentInChildren<Cam> ();
		targetSpeed = this.speed;
		if (keyEvent == null) {
			keyEvent = new UnityEvent ();
		}
		keyEvent.AddListener (movement);
	}
	
	// Update is called once per frame
	void Update () {
		updateCam ();
		if (Input.anyKey && keyEvent != null) {
			
			keyEvent.Invoke ();
		} else {
			this.speed = 0f;
			this.t = 0.6f;
		}
	
	}
	void updateCam(){
		cam.transform.SetPositionAndRotation (new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z + 0.2f), Quaternion.identity);
		cam.transform.eulerAngles = new Vector3(cam.yRotate * sensitivityMultiplier, cam.xRotate * sensitivityMultiplier, 0.0f);
	}
	void movement(){
		this.speed = Mathf.Lerp (0.2f, targetSpeed, t);
		t = 0.6f * Time.deltaTime;

			//Vector3.Angle (lastMousePos, Input.mousePosition);
	
		if (Input.GetKey ("d")) {
			this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x + this.speed * (Mathf.Sqrt(2) - 1), this.transform.position.y, this.transform.position.z), Quaternion.identity);
			if (Input.GetKey ("w")) {
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + this.speed), Quaternion.identity);
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x + this.speed , this.transform.position.y, this.transform.position.z), Quaternion.identity);
				return;
			} else if (Input.GetKey ("s")) {
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - this.speed), Quaternion.identity);
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x + this.speed, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				return;
			}
			this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x + this.speed, this.transform.position.y, this.transform.position.z), Quaternion.identity);
		} else if (Input.GetKey ("a")) {
			this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x - speed * (Mathf.Sqrt(2) - 1), this.transform.position.y, this.transform.position.z), Quaternion.identity);
			if (Input.GetKey ("w")) {
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + speed), Quaternion.identity);
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x - speed, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				return;
			} else if (Input.GetKey ("s")) {
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - speed), Quaternion.identity);
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x - speed, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				return;
			}
			this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x - speed, this.transform.position.y, this.transform.position.z), Quaternion.identity);
		} else if (Input.GetKey ("s")) {
			this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - 2*speed), Quaternion.identity);

		} else if (Input.GetKey ("w")) {
			this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 2*speed), Quaternion.identity);
		}
	}
}
