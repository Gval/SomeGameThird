using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoldierController : MonoBehaviour {

	private Leader soldierPawn;

	private 

	private Collider myTrans;

	[SerializeField]
	public List<Order> ordersList;

	void Start () {
		soldierPawn = GetComponent<Leader> ();

	}

	void Update () {

		if (!soldierPawn.isActing () ) {
			FUCK();
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
		case "Blue" :
			foreach (SoldierPawn pawn in soldierPawn.soldierList) {
				pawn.SetOrder (ordersList[0].resultMessage, soldierPawn);
			}
			break;
		case "Red" :
			foreach (SoldierPawn pawn in soldierPawn.soldierList) {
				pawn.SetOrder (ordersList[1].resultMessage, );
			}
			break;
		case "Yellow" :
			foreach (SoldierPawn pawn in soldierPawn.soldierList) {
				pawn.SetOrder (ordersList[2].resultMessage, );
			}
			break;
		}
	}


}
