using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	private SoldierPawn pawnOwner;
	public float health;
	public GameObject cadaverPrefab;

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
		Debug.Log (this.gameObject.name + " take damage : " + damage);
		health -= damage;
		if (health <= 0) {
			Die();
		}
	}

	void Die() {
		Debug.Log (gameObject.name + " : Je me meurs");
		GameObject cadaver = (GameObject) Instantiate (cadaverPrefab, transform.position, transform.rotation);
		cadaver.GetComponent<Cadaver> ().team = pawnOwner.team;
		this.gameObject.SetActive (false);
	}
}
