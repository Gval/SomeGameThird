using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoldierPawn : MonoBehaviour {


	CharacterController controller;

	public float moveSpeed = 5;

	public string cOrder = "";

	public int team = 1;

	// if true the character is doing something
	bool act = false;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (cOrder) {
		case ("March") :
			March ();
			break;
		case ("Stop"):
			Stop();
			break;
		default :
			break;
		}
	}

	public void SetOrder(string order) {
		cOrder = order;
	}

	public void Speak() {
		Debug.Log ("Oy Mate");
		Stop ();
	}

	public void March() {
		Vector3 velocity = transform.forward * moveSpeed;
		velocity = transform.TransformDirection (velocity);		
		controller.Move (velocity * Time.deltaTime);
	}

	public void Stop() {
		cOrder = "";
	}

	public bool isActing() {
		return true;
	}
}
