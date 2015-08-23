using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoldierPawn : MonoBehaviour {

	CharacterController controller;

	public HealthManager healthManager;
	public SignalSender	signalSender;
	public PheromoneManager pheromoneManager;

	[SerializeField]
	public float moveSpeed = 5;

	public float reloadTime = 5;
	public float cReload = 0;

	public float aimTime = 5;
	public float cAim = 0;
	
	public GameObject bulletPrefab;

	public int team = 1;

	public float redFlag;
	public float greenFlag;
	public float blueFlag;

	public string cOrder = "";


	/*
	 * Used to calculate the orientation and diraction of the player
	 */

	public int intBeforeAct = 0;

	public Vector3 moveDirection;

	[SerializeField]
	private float pheromoneCleanRepeat;

	public List<int> enemyDirection = new List<int> ();
	public List<int> friendDirection = new List<int> ();
	public List<int> deadDirection = new List<int> ();
	public List<int> treeDirection = new List<int> ();

	public List<float> pheromoneAngles = new List<float> ();
	public Vector3 pheromoneAngle;

	// if true the character is doing something
	bool act = false;
	public bool isLined = false;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		healthManager = GetComponent<HealthManager> ();
		signalSender = GetComponent<SignalSender> ();
		pheromoneManager = GetComponent<PheromoneManager> ();

		for (int i = 7; i >= 0 ; i--) {
			enemyDirection.Add (0);
			friendDirection.Add (0);
			deadDirection.Add(0);
			treeDirection.Add(0);
		}

		InvokeRepeating ("CleanPheromone", 0.1f, pheromoneCleanRepeat);

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
	

		intBeforeAct--;

	switch (cOrder) {
		case ("March") :
			March ();
			break;
		case ("MarchTowardEnemy"):
			MarchTowardFoes();
			break;
		case ("MarchTowardFriend"):
			MarchTowardFriend();
			break;
		case ("Stop"):
			Stop();
			break;
		case ("Speak"):
			moveRandomly();
			//Speak();
			break;
		case ("Wait") :
			moveRandomly();
			break;
		case ("PrepareShoot"):
			PrepareShoot();
			break;
		case ("Reload"):
			Reload();
			break;
		case ("Aim"):
			Aim();
			break;
		default :
			break;
		}

		if (act == true && intBeforeAct <= 0) {
			act = false;
		}
	}

	public void SetOrder(string order) {
		cOrder = order;
	}

	/*public void Speak() {
		Debug.Log ("Oy Mate");
		Stop ();
	}*/

	public void March() {
		Vector3 velocity = transform.forward * moveSpeed;
		velocity = transform.TransformDirection (velocity);		
		controller.Move (velocity * Time.deltaTime);
	}

	public void MarchTowardFoes() {
		if (HasDirection(enemyDirection)) {
			MoveTo (FindDirection(enemyDirection));
		} else {

		}
	}

	public void MarchTowardFriend() {
		if (HasDirection (friendDirection)) {
			MoveTo (FindDirection (friendDirection));
		} else {

		}
	}



	public void Stop() {
		cOrder = "";
	}
	
	public void Reload() {
		if (cReload <= reloadTime) {
			cReload += Time.deltaTime;
		}
	}

	public bool isReloaded() {
		if (cReload >= reloadTime) {
			return true;
		}
		return false;
	}

	public void Aim() {
		if (cAim <= aimTime) {
			cAim += Time.deltaTime;
		}
	}

	public bool isAimed() {
		if (cAim >= aimTime) {
			return true;
		}
		return false;
	}

	public void Shoot() {
		cReload = 0;
		cAim = 0;
		Instantiate(bulletPrefab, transform.position + transform.forward * 2, transform.rotation);
	}

	public void PrepareShoot() {
		intBeforeAct = 200;
		act = true;
		if (!isReloaded ()) {
			Reload();
			return;
		}
		Debug.Log ("Reload Ready!");
		if (!isAimed ()) {
			Aim();
			return;
		}
		Debug.Log ("AimReady");
		Shoot ();
	}

	public void Die() {
		Debug.Log ("Suicide");
		healthManager.TakeDamage (999);
	}


	

	public void ReceiveFlagPheromone(string type) {
		switch (type) {
		case "red":
			redFlag++;
			break;
		case "blue":
			blueFlag++;
			break;
		case "green":
			greenFlag++;
			break;
		}
	}



	public Vector3 FindDirection(List<int> directionList) {
		int maxIndex;
		int maxValue;
		
		maxIndex = 0;
		maxValue = directionList [maxIndex];
		for (int index = 7; index > 0; index--) {
			if (directionList[index] > maxValue) {
				maxIndex = index;
				maxValue = directionList[index];
			}
		}
		return Quaternion.AngleAxis (pheromoneAngles [maxIndex], Vector3.up) * Vector3.forward;
	}

	public bool HasDirection(List<int> directionList) {
		for (int index = 7; index > 0; index--) {
			if (directionList[index] > 0) {
				return true;
			}
		}
		return false;
	}

	public bool isActing() {
		return act;
	}

	public void OnGUI() {
	}

	public void Wait() {
		act = true;
		intBeforeAct = Random.Range(25,75);
		cOrder = "Wait";
		moveDirection = new Vector3(Random.Range(-359, 359),0,Random.Range(-359, 359)).normalized;
	}

	public int findStrongestDirection(List<int> directionList)
	{
		int maxIndex;
		int maxValue;
		
		maxIndex = 0;
		maxValue = directionList [maxIndex];
		for (int index = 7; index > 0; index--) {
			if(directionList[index] > 3)
			{
				int g = 0;
			}
			if (directionList[index] > maxValue) {
				maxIndex = index;
				maxValue = directionList[index];
			}
		}

		return maxValue;
	}

	public void moveRandomly() {
		transform.position += moveDirection * 0.1f;
	}

	public void CleanPheromone() {
		for (int i = 0 ; i <= 7 ; i++) {
			if (enemyDirection[i] > 0) {
				enemyDirection[i]--;
			}
		}
	}

	public void Courrir() {
	}

	public void Tirer() {
	}	


	/*
	 *  MES MODIFS
	 * 
	 * */



	public Vector3 FindDirectionOther(List<int> directionList, string s) {
		int maxIndex;
		int maxValue;
		
		maxIndex = 0;
		maxValue = directionList [maxIndex];
		for (int index = 7; index > 0; index--) {
			if (directionList[index] > maxValue) {
				maxIndex = index;
				maxValue = directionList[index];
			}
		}
		
		switch(s) {
		case "right":
			maxIndex +=2;
			if(maxIndex > 7)
			{
				maxIndex -= 8;
			}
			break;
		case "left":
			maxIndex -=2;
			if(maxIndex < 0)
			{
				maxIndex += 8;
			}
			break;
		case "back" :
			maxIndex -=4;
			if(maxIndex < 0)
			{
				maxIndex += 8;
			}
			break;
		}
		
		return Quaternion.AngleAxis (pheromoneAngles [maxIndex], Vector3.up) * Vector3.forward;
	}

	public void MarchLeftToFoes() {
		if (HasDirection(enemyDirection)) {
			MoveTo (FindDirectionOther(enemyDirection, "left"));
		} else {

		}
	}
	
	public void MarchRightToFoes() {
		if (HasDirection(enemyDirection)) {
			MoveTo (FindDirectionOther(enemyDirection, "right"));
		} else {

		}
	}
	
	public void MarchBackwardFoes() {
		if (HasDirection(enemyDirection)) {
			MoveTo (FindDirectionOther(enemyDirection, "back"));
		} else {

		}
	}

	public void MoveTo(Vector3 target) {
		CleanAllPheromones ();
		intBeforeAct = Random.Range(50, 125);
		act = true;
		Vector3 velocity = target * moveSpeed;
		velocity = transform.TransformDirection (velocity);		
		controller.Move (velocity * Time.deltaTime);
	}

	public void CleanAllPheromones()
	{
		Debug.Log ("DoubleFuck");
		for (int i = 0 ; i <= 7 ; i++) {
			enemyDirection[i] = 0;
			friendDirection[i] = 0;
		}
	}

	public void ReceivePheromone(Transform emitter, List<int> directionList) {
		Vector3 f = emitter.position - transform.position; 
		f.y += 1; 
		pheromoneAngle = Quaternion.LookRotation (f).eulerAngles;
		if (pheromoneAngle.y > 331 && pheromoneAngle.y < 360 || pheromoneAngle.y >= 0 && pheromoneAngle.y < 30) {
			directionList[0] += 1;
		}
		if (pheromoneAngle.y > 31 && pheromoneAngle.y < 60) {
			directionList[1] += 1;
		}
		if (pheromoneAngle.y > 61 && pheromoneAngle.y < 120) {
			directionList[2] += 1;
		}
		if (pheromoneAngle.y > 121 && pheromoneAngle.y < 150) {
			directionList[3] += 1;
		}
		if (pheromoneAngle.y > 151 && pheromoneAngle.y < 210) {
			directionList[4] += 1;
		}
		if (pheromoneAngle.y > 211 && pheromoneAngle.y < 240) {
			directionList[5] += 1;
		}
		if (pheromoneAngle.y > 241 && pheromoneAngle.y < 300) {
			directionList[6] += 1;
		} if (pheromoneAngle.y > 301 && pheromoneAngle.y < 330) {
			directionList[7] += 1;
		}
	}
}