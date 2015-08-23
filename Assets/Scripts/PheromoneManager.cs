using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PheromoneManager : MonoBehaviour {

	private SoldierPawn pawn;
	private Cadaver cadaver;

	public List<SoldierPawn> others = new List<SoldierPawn> ();
	public List<Cadaver> cadavers = new List<Cadaver>();
	public int team;

	// Use this for initialization
	void Start () {
		if ((pawn = GetComponentInParent<SoldierPawn> ()) != null) {
			team = pawn.team;
		} else if ((cadaver = GetComponentInParent<Cadaver>()) != null) {
			team = cadaver.team;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			Debug.Log("Send pheromone");
			SendPresencePheromone();
		}
	}

	public void SendPresencePheromone(){
		foreach (SoldierPawn other in others) {
			if (!other.isActiveAndEnabled) {
				others.Remove(other);
				return ;
			}
			if (other.team != team) {
				other.ReceivePheromone(pawn.transform, other.enemyDirection);
			} else if (other.team == team) {
				other.ReceivePheromone(pawn.transform, other.friendDirection);
			}
		}
	}	

	public void SendDeathPheromone() {
		foreach (SoldierPawn other in others) {
			if (!other.isActiveAndEnabled || other == null) {
				others.Remove(other);
				return ;
			}
			if (pawn == null) {
				Debug.Log("Pawn null");
				return;
			}
			if (other.team == team) {
				other.ReceivePheromone(pawn.transform, other.deadDirection);
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
