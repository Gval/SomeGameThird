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
	}

	void Update () {

		//if (!soldierPawn.isActing()) {
		//	FUCK();
		//}
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
		SendMessage(Process ());
	}


}
