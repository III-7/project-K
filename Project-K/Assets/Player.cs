using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Player : MonoBehaviour {
	UnityEvent keyEvent;
	float speed = 0.1f;

	// Use this for initialization
	void Start () {
		if (keyEvent == null) {
			keyEvent = new UnityEvent ();
		}
		keyEvent.AddListener (movement);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey && keyEvent != null) {
			
			keyEvent.Invoke ();
		}
	
	}
	void movement(){
		if (Input.GetKey ("d")) {
			this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x + speed * (Mathf.Sqrt(2) - 1), this.transform.position.y, this.transform.position.z), Quaternion.identity);
			if (Input.GetKey ("w")) {
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + speed), Quaternion.identity);
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x + speed, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				return;
			} else if (Input.GetKey ("s")) {
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - speed), Quaternion.identity);
				this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x + speed, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				return;
			}
			this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x + speed, this.transform.position.y, this.transform.position.z), Quaternion.identity);
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
