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
	public bool done = false;

	[SerializeField]
	public GameObject prefab;

	GameObject thing;

	public Order newOrder;

	// Use this for initialization
	void Start () {
		Spawn ();
	}

	void Spawn() {

		for (int i = 0; i < 1000; i++) {
			float num = Random.Range(0, 55);
			Vector3 pos = RandomCircle(this.transform.localPosition, num);
			soldierList.Add(Instantiate(prefab, pos, this.transform.localRotation) as GameObject);
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
			foreach(SoldierController sold in soldierComponentList)
			{
				sold.ordersList.Add(newOrder);
				newOrder = null;
			}
		}
		else if (condition) {
			if(GUI.Button(new Rect(15, 50, 150, 30), AllEnums.ObjectsEnums.Enemy.ToString()))
			{
				newOrder.toEvaluate.taging = AllEnums.ObjectsEnums.Enemy.ToString();
				done = true;
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
				newOrder.resultMessage = AllEnums.messagesEnums.Marcher.ToString();
				evaluator = true;
			}
		}

		Orders ();
	}

	void Orders(){

		for(int i =0; i < soldierComponentList[0].ordersList.Count ; i++)
		{
			string s = soldierComponentList[0].ordersList[i].resultMessage + " " + soldierComponentList[0].ordersList[i].toEvaluate.ToString() + " " + soldierComponentList[0].ordersList[i].toEvaluate.taging;
			if(GUI.Button( new Rect(5, 250 + (50*i), 400, 30), s))
			{

			}
		}
	}

}