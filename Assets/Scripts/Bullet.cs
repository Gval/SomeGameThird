using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public float damage = 10;
	public float bulletForce = 1000;
	public float lifeSpan;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (transform.forward * bulletForce);
	}

	public void Update() {
		lifeSpan -= Time.deltaTime;
		if (lifeSpan <= 0) {
			Die();
		}
	}

	void Die() {
		Destroy (this.gameObject);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Soldier") {
			collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
			Die();
		}
	}
}
