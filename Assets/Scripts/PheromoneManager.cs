using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PheromoneManager : MonoBehaviour {

	private SoldierPawn pawn;
	public List<SoldierPawn> enemies = new List<SoldierPawn> ();

	// Use this for initialization
	void Start () {
		pawn = GetComponent<SoldierPawn> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			Debug.Log("Send pheromone");
			SendPheromone();
		}
	}

	void SendPheromone(){
		foreach (SoldierPawn enemie in enemies) {
			enemie.ReceivePheromone (pawn);
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Soldier" && collider.GetComponent<SoldierPawn> ().team != pawn.team) {
			enemies.Add(collider.GetComponent<SoldierPawn>());
		}
	}

	void OnTriggerExit(Collider collider) {
		enemies.Remove (collider.GetComponent<SoldierPawn>());
	}
}
