using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {
	public Player player;
	private void OnCollisionEnter(Collision c){
		//hit something

		print ("ground");
	}
	private void OnCollisionStay(Collision c){
		//hitting something
		player.jumpAllowed = true;
	}
	private void OnCollisionExit(Collision c){
		//no longer hitting something
		player.jumpAllowed = false;
		print ("jumping");
	}
}
