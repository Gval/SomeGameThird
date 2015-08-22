using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PheromoneManager : MonoBehaviour {

	private SoldierPawn pawn;
	public List<SoldierPawn> enemies = new List<SoldierPawn> ();
	public int team;

	// Use this for initialization
	void Start () {
		pawn = GetComponentInParent<SoldierPawn> ();
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
			if (enemie.team != team) {
				enemie.ReceivePheromone (pawn);
			}
		}
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log ("colli : " + collider.name);
		if (collider.tag == "Soldier") {
			enemies.Add(collider.GetComponent<SoldierPawn>());
		}
	}

	void OnTriggerExit(Collider collider) {
		enemies.Remove (collider.GetComponent<SoldierPawn>());
	}
}
