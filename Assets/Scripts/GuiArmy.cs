using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuiArmy : MonoBehaviour {

	[SerializeField]
	public List<GameObject> soldierList;

	public List<SoldierController> soldierComponentList;

	[SerializeField]
	public bool condition = false;

	[SerializeField]
	public bool evaluator = false;

	[SerializeField]
	public bool groupe = false;

	[SerializeField]
	public bool number = false;

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

		SingletonLeader sL = SingletonLeader.Instance;

		for (int i = 0; i < 10; i++) {
			float num = Random.Range(0, range);
			Vector3 pos = RandomCircle(this.transform.localPosition, num);
			GameObject lead = Instantiate(prefabLeader, pos, this.transform.localRotation) as GameObject;
			soldierList.Add(lead);
			sL.leaderPlayerList.Add(lead);
			for (int y = 0; y < (numberRange/10); y++) {
				float num2 = Random.Range(0, range);
				Vector3 pos2 = RandomCircle(this.transform.localPosition, num);
				GameObject s = Instantiate(prefab, pos2, this.transform.localRotation) as GameObject;
				soldierList.Add(s);
				Leader l = lead.GetComponent<Leader>();
				l.soldierList.Add(s);
			}
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
			condition = false;
			evaluator = false;
			done = false;
			for(int i = 0; i < soldierComponentList.Count; i++)
			{
				/*newOrder.toEvaluate.soldierPawn = soldierList[i].GetComponent<SoldierPawn>();
				newOrder.toEvaluate.myObj = soldierList[i];
				soldierComponentList[i].ordersList.Add(newOrder);*/

			}

			newOrder = null;
		} else if (number) {
			if(GUI.Button(new Rect(15, 50, 150, 30), "20"))
			{
				newOrder.toEvaluate.numberToEvaluate = 20;
				done = true;
			}
			if(GUI.Button(new Rect(15, 50, 150, 30), "15"))
			{
				newOrder.toEvaluate.numberToEvaluate = 15;
				done = true;
			}
			if(GUI.Button(new Rect(15, 50, 150, 30), "10"))
			{
				newOrder.toEvaluate.numberToEvaluate = 10;
				done = true;
			}
			if(GUI.Button(new Rect(15, 50, 150, 30), "5"))
			{
				newOrder.toEvaluate.numberToEvaluate = 5;
				done = true;
			}
		}
		else if (condition) {
			if(GUI.Button(new Rect(15, 50, 150, 30), AllEnums.ObjectsEnums.Enemy.ToString()))
			{
				newOrder.toEvaluate.taging = AllEnums.ObjectsEnums.Enemy.ToString();
				number = true;
			}
		} else if (evaluator) {
			if(GUI.Button(new Rect(15,50,150,30), AllEnums.TypeConditionEnums.Distance.ToString()))
			{
				Condition s = gameObject.AddComponent<DistanceEvaluator>();
				newOrder.toEvaluate = s;
				condition = true;
			}
		}else {
			if(GUI.Button(new Rect(15, 50, 150, 30), AllEnums.messagesEnums.Marcher.ToString()))
			{
				newOrder = gameObject.AddComponent<MoveOrder>();
				newOrder.resultMessage = AllEnums.messagesEnums.Courrir.ToString();
				evaluator = true;
			}
		}

		Orders ();
	}

	void Orders(){

		/*for(int i =0; i < soldierComponentList[0].ordersList.Count ; i++)
		{
			string s = soldierComponentList[0].ordersList[i].resultMessage + " " + soldierComponentList[0].ordersList[i].toEvaluate.ToString() + " " + soldierComponentList[0].ordersList[i].toEvaluate.taging;
			if(GUI.Button( new Rect(5, 250 + (50*i), 400, 30), s))
			{

			}
		}*/
	}

}