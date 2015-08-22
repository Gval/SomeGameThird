using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoldierController : MonoBehaviour {

	private SoldierPawn soldierPawn;

	private Collider myTrans;

	[SerializeField]
	public List<Order> ordersList;

	void Start () {
		soldierPawn = GetComponent<SoldierPawn> ();
		myTrans = this.transform.GetComponent<SphereCollider>();
	}

	void Update () {

		if (!soldierPawn.isActing () && myTrans.isTrigger == false) {
			myTrans.isTrigger = true;
		} else if (!soldierPawn.isActing () && myTrans.isTrigger == true) {
			FUCK();
			myTrans.isTrigger = false;
		}
	}

	private string Process() {

		string result = "Wait";

		for(int i = 0; i < ordersList.Count; i++)
		{
			if(ordersList[i].isConditionTrue())
			{
				result = ordersList[i].ProceedOrder();
			}
		} 

		return result;
	}

	public void FUCK()
	{
		switch (Process ()) {
		case "Wait" :
			soldierPawn.Wait();
			break;
		case "Courrir" :
			soldierPawn.Courrir();
			break;
		case "Tirer" :
			soldierPawn.Tirer();
			break;
		}
	}

	void OnTriggerEnter (Collider collider) {
		Debug.Log ("BITCH");
		if (collider.tag == "Enemy") {
			//objToEvaluate = collider.GetComponent<GameObject>();
		}
	}


}
