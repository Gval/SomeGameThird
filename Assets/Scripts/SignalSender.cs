using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SignalSender : MonoBehaviour {

	public List<SoldierPawn> pawns = new List<SoldierPawn>();

	public void SendFlag(int team, string color) {
		foreach (SoldierPawn pawn in pawns) {
			if (pawn.team == team) {
				pawn.ReceiveFlagPheromone(color);
			}
		}
	}

	public void SendDead(int team) {
		foreach (SoldierPawn pawn in pawns) {
			if (pawn.team == team) {
				pawn.ReceivePheromone(this.gameObject.transform, pawn.deadDirection);
			}
		}
	}

	public void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Soldier") {
			pawns.Add(collider.GetComponent<SoldierPawn>());
		}
	}

	public void OnTriggerExit(Collider collider) {
		pawns.Remove(collider.GetComponent<SoldierPawn>());
	}
}
