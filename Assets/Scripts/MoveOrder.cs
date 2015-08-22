using UnityEngine;
using System.Collections;

public class MoveOrder : Order {

	public override string ProceedOrder()
	{
		string resultType = resultMessage;
		
		if(leftChild != null && leftChild.isConditionTrue())
		{
			resultType = leftChild.ProceedOrder();
		} else if (rightChild != null && rightChild.isConditionTrue())
		{
			resultType = leftChild.ProceedOrder();
		}
		
		return resultType;
		
	}
	
	public override bool isConditionTrue()
	{
		return toEvaluate.CompareObject ();
	}
}
