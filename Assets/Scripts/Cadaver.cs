using UnityEngine;
using System.Collections;

public class Cadaver : MonoBehaviour {
	private PheromoneManager pheromoneManager;
	public float deathPheromoneRate;
	public int team;

	// Use this for initialization
	void Start () {
		pheromoneManager = GetComponentInChildren<PheromoneManager> ();
		InvokeRepeating ("SendDeathPheromone", 0.1f, deathPheromoneRate);
	}

	public void SendDeathPheromone() {
		Debug.Log ("Send death");
		pheromoneManager.SendDeathPheromone ();
	}
}
