using UnityEngine;
using System.Collections;

public abstract class Condition  : MonoBehaviour {
	
	[SerializeField]
	public GameObject objToEvaluate;

	[SerializeField]
	public GameObject myObj;

	[SerializeField]
	public SoldierPawn soldierPawn;

	public SingletonLeader singleLeader;

	public int numberToEvaluate;

	public string taging;

	public abstract bool CompareObject();
}
