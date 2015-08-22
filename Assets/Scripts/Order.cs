using UnityEngine;
using System.Collections;

public abstract class Order : MonoBehaviour {

	[SerializeField]
	public string resultMessage;

	[SerializeField]
	public Order leftChild;

	[SerializeField]
	public Order rightChild;

	[SerializeField]
	public Condition toEvaluate;
	
	public abstract string ProceedOrder ();

	public abstract bool isConditionTrue ();
}
