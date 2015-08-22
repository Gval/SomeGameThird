using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoldierController : MonoBehaviour {

	private SoldierPawn soldierPawn;

	[SerializeField]
	public List<Order> ordersList;

	void Start () {
		soldierPawn = GetComponent<SoldierPawn> ();
	}

	void Update () {
		if (!soldierPawn.isActing ()) {
			SendMessage(Process());
		}
	}

	private string Process() {

		string result = "Speak";

		for(int i = 0; i < ordersList.Count; i++)
		{
			if(ordersList[i].isConditionTrue())
			{
				result = ordersList[i].ProceedOrder();
			}
		} 

		return result;
	}

	

}
