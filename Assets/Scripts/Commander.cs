using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Commander : MonoBehaviour {

	private CharacterController controller;
	public List<SoldierPawn> soldiers = new List<SoldierPawn>();

	[SerializeField]
	public float	moveSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}

	void Update () {
		Move ();
		Order ();
	}

	void Move() {

		Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
		//Debug.Log ("direction : " + direction);
		Vector3 velocity = direction * moveSpeed;
		//Debug.Log ("moveSpeed : " + moveSpeed);
		velocity = transform.TransformDirection (velocity);
		//Debug.Log ("velocity : " + moveSpeed);
		transform.position += velocity;
		//controller.Move (velocity);
	}

	void Order() {
		if (Input.GetKeyDown ("1")) {
			foreach (SoldierPawn pawn in soldiers) {
				Debug.Log("March");
				pawn.SetOrder("March");
			}
		}
		if (Input.GetKeyDown ("2")) {
			foreach (SoldierPawn pawn in soldiers) {
				Debug.Log("Stop");
				pawn.SetOrder ("Stop");
			}
		}
		if (Input.GetKeyDown ("3")) {
			foreach (SoldierPawn pawn in soldiers) {
				Debug.Log("MarchTowardEnemy");
				pawn.SetOrder ("MarchTowardEnemy");
			}
		}
		if (Input.GetKeyDown ("4")) {
			foreach (SoldierPawn pawn in soldiers) {
				Debug.Log("MarchTowardFriend");
				pawn.SetOrder ("MarchTowardFriend");
			}
		}
		if (Input.GetKeyDown ("5")) {
			foreach (SoldierPawn pawn in soldiers) {
				Debug.Log("PrepareShoot");
				pawn.SetOrder ("PrepareShoot");
			}
		}
		if (Input.GetKeyDown ("6")) {
			foreach (SoldierPawn pawn in soldiers) {
				Debug.Log("Reload");
				pawn.SetOrder ("Reload");
			}
		}
		if (Input.GetKeyDown ("7")) {
			foreach (SoldierPawn pawn in soldiers) {
				Debug.Log("Aim");
				pawn.SetOrder ("Aim");
			}
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Soldier" && collider.GetComponent<SoldierPawn>().team == 1) {
			if (!soldiers.Contains(collider.GetComponent<SoldierPawn>())) {
				soldiers.Add(collider.GetComponent<SoldierPawn>());
			}
		}
	}

	void OnTriggerExit(Collider collider) {
		soldiers.Remove(collider.GetComponent<SoldierPawn>());
	}
}
