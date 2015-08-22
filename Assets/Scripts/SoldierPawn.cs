using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoldierPawn : MonoBehaviour {

	CharacterController controller;

	public float moveSpeed = 5;

	public string cOrder = "";

	public int team = 1;

	public List<int> pheromoneDirection = new List<int> ();
	public List<Quaternion> pheromoneQuaternion = new List<Quaternion> ();
	public List<float> pheromoneAngles = new List<float> ();

	public Vector3 pheromoneAngle;

	// if true the character is doing something
	bool act = false;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();

		for (int i = 7; i >= 0 ; i--) {
			pheromoneDirection.Add (0);
		}
		pheromoneQuaternion.Add (Quaternion.AngleAxis(0, Vector3.up)); 
		pheromoneQuaternion.Add (Quaternion.AngleAxis(45, Vector3.up)); 
		pheromoneQuaternion.Add (Quaternion.AngleAxis(90, Vector3.up)); 
		pheromoneQuaternion.Add (Quaternion.AngleAxis(135, Vector3.up));
		pheromoneQuaternion.Add (Quaternion.AngleAxis(180, Vector3.up));
		pheromoneQuaternion.Add (Quaternion.AngleAxis(225, Vector3.up));
		pheromoneQuaternion.Add (Quaternion.AngleAxis(270, Vector3.up));
		pheromoneQuaternion.Add (Quaternion.AngleAxis(315, Vector3.up));

		pheromoneAngles.Add (0); 
		pheromoneAngles.Add (45); 
		pheromoneAngles.Add (90); 
		pheromoneAngles.Add (135);
		pheromoneAngles.Add (180);
		pheromoneAngles.Add (225);
		pheromoneAngles.Add (270);
		pheromoneAngles.Add (315);
	}
	
	// Update is called once per frame
	void Update () {
		switch (cOrder) {
		case ("March") :
			March ();
			break;
		case ("MarchTowardEnemy"):
			MarchTowardEnemy();
			break;
		case ("Stop"):
			Stop();
			break;
		case ("Speak"):
			Speak();
			break;
		default :
			break;
		}
	}

	public void SetOrder(string order) {
		cOrder = order;
	}

	public void Speak() {
		Debug.Log ("Oy Mate");
		Stop ();
	}

	public void March() {
		Vector3 velocity = transform.forward * moveSpeed;
		velocity = transform.TransformDirection (velocity);		
		controller.Move (velocity * Time.deltaTime);
	}

	public void MarchTowardEnemy() {
		Vector3 velocity = FindEnemyDirection() * moveSpeed;
		velocity = transform.TransformDirection (velocity);		
		controller.Move (velocity * Time.deltaTime);
	}

	public void Stop() {
		cOrder = "";
	}

	public void ReceivePheromone(SoldierPawn emitter) {
		pheromoneAngle = Quaternion.LookRotation (emitter.transform.position -  transform.position).eulerAngles;
		if (pheromoneAngle.y > 331 && pheromoneAngle.y < 360 || pheromoneAngle.y >= 0 && pheromoneAngle.y < 30) {
			pheromoneDirection[0] += 2;
		}
		if (pheromoneAngle.y > 31 && pheromoneAngle.y < 60) {
			pheromoneDirection[1] += 2;
		}
		if (pheromoneAngle.y > 61 && pheromoneAngle.y < 120) {
			pheromoneDirection[2] += 2;
		}
		if (pheromoneAngle.y > 121 && pheromoneAngle.y < 150) {
			pheromoneDirection[3] += 1;
		}
		if (pheromoneAngle.y > 151 && pheromoneAngle.y < 210) {
			pheromoneDirection[4] += 1;
		}
		if (pheromoneAngle.y > 211 && pheromoneAngle.y < 240) {
			pheromoneDirection[5] += 1;
		}
		if (pheromoneAngle.y > 241 && pheromoneAngle.y < 300) {
			pheromoneDirection[6] += 1;
		} if (pheromoneAngle.y > 301 && pheromoneAngle.y < 330) {
			pheromoneDirection[7] += 1;
		}
	}

	public Vector3 FindEnemyDirection() {
		int max;
		max = 0;
		for (int index = 7; index > 0; index--) {
			if (pheromoneDirection[index] > max) {
				max = index;
			}
		}
		return Quaternion.AngleAxis (pheromoneAngles [max], Vector3.up) * Vector3.forward;
	}

	public bool isActing() {
		return act;
	}

	public void OnGUI() {
		GUI.Label(new Rect(300, team * 50, 200, 100), "angle pheromone : " + pheromoneAngle.y);
	}
}