using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuiArmy : MonoBehaviour {

	[SerializeField]
	public List<GameObject> soldierList;

	public List<SoldierController> soldierComponentList;

	[SerializeField]
	public bool evaluator = false;

	[SerializeField]
	public bool direction = false;

	[SerializeField]
	public bool done = false;

	[SerializeField]
	public GameObject prefab;

	[SerializeField]
	public GameObject prefabLeader;

	[SerializeField]
	public int numberRange = 250;

	[SerializeField]
	public int range = 25;

	GameObject thing;

	public Order newOrder;

	// Use this for initialization
	void Start () {
		Spawn ();
	}

	void Spawn() {

			for (int y = 0; y < numberRange; y++) {
				float num2 = Random.Range(0, range);
				Vector3 pos2 = RandomCircle(this.transform.localPosition, range);
				GameObject s = Instantiate(prefab, pos2, this.transform.localRotation) as GameObject;
				SoldierPawn p = s.GetComponent<SoldierPawn>();
				soldierList.Add(s);

		}
	
		foreach(GameObject obj in soldierList)
		{
			SoldierController s = obj.GetComponent<SoldierController>();
			soldierComponentList.Add(s);
		}
	}

	Vector3 RandomCircle ( Vector3 center ,   float radius  ){
		float ang = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = center.y;
		pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		return pos;
	}
	
	void OnGUI(){
		
		if (done) {
			direction = false;
			evaluator = false;
			done = false;
			for(int i = 0; i < soldierComponentList.Count; i++)
			{
				newOrder.toEvaluate = gameObject.AddComponent<DistanceEvaluator>() as DistanceEvaluator ;
				newOrder.toEvaluate.whatToDoSir = newOrder.whoIsItSir;
				newOrder.resultMessage = getResultMessage();
				newOrder.toEvaluate.soldierPawn = soldierList[i].GetComponent<SoldierPawn>();
				newOrder.toEvaluate.myObj = soldierList[i];
				soldierComponentList[i].ordersList.Add(newOrder);

			}
			newOrder = null;
		} else if (direction) {
			DisplayDirections();
		}
		else if (evaluator) {
			DisplayOrders();
		}else {
			DisplayEvaluators();
		}

		Orders ();
	}

	void Orders(){
		/*for(int i =0; i < soldierComponentList[0].ordersList.Count ; i++)
		{
			string s = soldierComponentList[0].ordersList[i].resultMessage + " " + soldierComponentList[0].ordersList[i].toEvaluate.ToString() + " " + soldierComponentList[0].ordersList[i].toEvaluate.whatToDoSir;
			if(GUI.Button( new Rect(5, 250 + (50*i), 400, 30), s))
			{

			}
		}*/
	}

	void DisplayEvaluators(){

		if (GUI.Button (new Rect (15, 50, 150, 30), "Fight")) {
			newOrder = gameObject.AddComponent<MoveOrder>() as MoveOrder;
			newOrder.whoIsItSir = AllEnums.ObjectsEnums.Fight.ToString();
			evaluator = true;
		}
		if (GUI.Button (new Rect (15, 80, 150, 30), "Friends")) {
			newOrder = gameObject.AddComponent<MoveOrder>() as MoveOrder;
			newOrder.whoIsItSir = AllEnums.ObjectsEnums.Friends.ToString();
			evaluator = true;
		}
		if (GUI.Button (new Rect (15, 11, 150, 30), "DeadFriends")) {
			newOrder = new MoveOrder();
			newOrder.whoIsItSir = AllEnums.ObjectsEnums.DeadFriends.ToString();
			evaluator = true;
		}
		if (GUI.Button (new Rect (15, 140, 150, 30), "DeadFoes")) {
			newOrder = gameObject.AddComponent<MoveOrder>() as MoveOrder;
			newOrder.whoIsItSir = AllEnums.ObjectsEnums.DeadFoes.ToString();
			evaluator = true;
		}
		if (GUI.Button (new Rect (15, 170, 150, 30), "Foes")) {
			newOrder = gameObject.AddComponent<MoveOrder>() as MoveOrder;
			newOrder.whoIsItSir = AllEnums.ObjectsEnums.Foes.ToString();
			evaluator = true;
		}
	}

	void DisplayOrders(){


		/*Marcher,
		Feu,
		Courrir,
		Wait,
		Attaque*/


		if (GUI.Button (new Rect (15, 20, 150, 30), "March")) {
			newOrder.whatToDoSir = AllEnums.messagesEnums.March.ToString();
			direction = true;
		}
		if (GUI.Button (new Rect (15, 50, 150, 30), "Fire")) {
			newOrder.whatToDoSir = AllEnums.messagesEnums.Fire.ToString();
			direction = true;
		}
		if (GUI.Button (new Rect (15, 80, 150, 30), "Wait")) {
			newOrder.whatToDoSir = AllEnums.messagesEnums.Wait.ToString();
			direction = true;
		}
		if (GUI.Button (new Rect (15, 110, 150, 30), "Attack")) {
			newOrder.whatToDoSir = AllEnums.messagesEnums.Attack.ToString();
			direction = true;
		}
	}

	void DisplayDirections(){
		if (GUI.Button (new Rect (15, 20, 150, 30), "Toward")) {
			newOrder.direction = AllEnums.Direction.Toward.ToString();
			done = true;
		}
		if (GUI.Button (new Rect (15, 50, 150, 30), "LeftTo")) {
			newOrder.direction = AllEnums.Direction.LeftTo.ToString();
			done = true;
		}
		if (GUI.Button (new Rect (15, 80, 150, 30), "RightTo")) {
			newOrder.direction = AllEnums.Direction.RightTo.ToString();
			done = true;
		}
		if (GUI.Button (new Rect (15, 110, 150, 30), AllEnums.Direction.Backward.ToString())) {
			newOrder.direction = AllEnums.Direction.Backward.ToString();
			done = true;
		}
	}

	string getResultMessage(){
		return newOrder.whatToDoSir + newOrder.direction + newOrder.whoIsItSir;
	}
}