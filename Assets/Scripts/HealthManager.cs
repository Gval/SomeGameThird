using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	private SoldierPawn pawnOwner;
	public float health;

	// Use this for initialization
	void Start () {
		pawnOwner = GetComponent<SoldierPawn> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	void OnCollisionEnter(Collision collision) {
		Debug.Log ("Collision with : " + collision.gameObject.name);
		if (collision.gameObject.tag == "Bullet") {
			TakeDamage(collision.gameObject.GetComponent<Bullet>());
		}
	}*/

	public void TakeDamage(float damage) {
		health -= damage;
		if (health <= 0) {
			Die();
		}
	}

	void Die() {
		Debug.Log (gameObject.name + " : Je me meurs");
		pawnOwner.pheromoneManager.SendDeathPheromone();
		Destroy (this.gameObject);
	}
}
