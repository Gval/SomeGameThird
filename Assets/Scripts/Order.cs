using UnityEngine;
using System.Collections;

public abstract class Order : MonoBehaviour {

	[SerializeField]
	public string resultMessage;

	public string direction;

	public string whatToDoSir;

	public string whoIsItSir;

	[SerializeField]
	public Condition toEvaluate;
	
	public abstract string ProceedOrder ();

	public abstract bool isConditionTrue ();
}
