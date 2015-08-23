using UnityEngine;
using System.Collections;

public abstract class Condition  : MonoBehaviour {
	
	[SerializeField]
	public GameObject objToEvaluate;

	[SerializeField]
	public GameObject myObj;

	[SerializeField]
	public SoldierPawn soldierPawn;

	public int numberToEvaluate;

	public string whatToDoSir;

	public abstract bool CompareObject();

	public abstract bool CompareObjectFight();

	public abstract bool CompareObjectFriends();

	public abstract bool CompareObjectDeadFriends();

	public abstract bool CompareObjectDeadFoes();

	public abstract bool CompareObjectFoes();
}
