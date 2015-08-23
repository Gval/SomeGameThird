using UnityEngine;
using System.Collections;

public class MoveOrder : Order {

	public override string ProceedOrder()
	{

		string resultType = resultMessage;

		return resultType;
		
	}
	
	public override bool isConditionTrue()
	{
		return toEvaluate.CompareObject ();
	}
}
