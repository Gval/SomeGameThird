using UnityEngine;
using System.Collections;

public class DebugGUI : MonoBehaviour {

	private Commander commander;
	
	void Start () {
		commander = GameObject.FindWithTag ("Player").GetComponent<Commander>();
	}

	void Update () {
	}

	void OnGUI() {
		float newY = 0;

		foreach (SoldierPawn pawn in commander.soldiers) {
			GUI.Label(new Rect(0, newY += 20, 200, 100), pawn.name); 
		}
	}
}
