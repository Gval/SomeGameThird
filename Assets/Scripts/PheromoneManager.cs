using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PheromoneManager : MonoBehaviour {

	private SoldierPawn pawn;
	public List<SoldierPawn> others = new List<SoldierPawn> ();
	public int team;
	public float pheromoneRate;

	// Use this for initialization
	void Start () {
		pawn = GetComponentInParent<SoldierPawn> ();
		team = pawn.team;
		InvokeRepeating ("SendPheromone", 1, pheromoneRate);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			Debug.Log("Send pheromone");
			SendPheromone();
		}
	}

	void SendPheromone(){
		foreach (SoldierPawn other in others) {
			if (other.team != team) {
				other.ReceivePheromone(pawn.transform, other.enemyDirection);
			} else if (other.team == team) {
				other.ReceivePheromone(pawn.transform, other.friendDirection);
			}
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Soldier") {
			others.Add(collider.GetComponent<SoldierPawn>());
		}
	}

	void OnTriggerExit(Collider collider) {
		others.Remove (collider.GetComponent<SoldierPawn>());
	}
}
