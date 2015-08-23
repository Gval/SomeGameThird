using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoldierController : MonoBehaviour {

	private Leader soldierPawn;

	private SoldierPawn body;

	private Collider myTrans;

	[SerializeField]
	public List<Order> ordersList;

	void Start () {
		soldierPawn = GetComponent<Leader> ();
		body = GetComponent<SoldierPawn> ();
	}

	void Update () {

		if (!body.isActing()) {
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
		case "MarchTowardEnemy" :

				pawn.SetTarget(ordersList[0].toEvaluate.target);
				pawn.SetOrder (ordersList[0].resultMessage);

			break;
		case "MarchLeftToEnemy" :

				pawn.SetTarget(ordersList[1].toEvaluate.target);
				pawn.SetOrder (ordersList[1].resultMessage);

			break;
		case "MarchRightToEnemy" :

				pawn.SetTarget(ordersList[2].toEvaluate.target);
				pawn.SetOrder (ordersList[2].resultMessage);

			break;
		}
	}


}
