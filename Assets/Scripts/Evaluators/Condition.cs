using UnityEngine;
using System.Collections;

public abstract class Condition  : MonoBehaviour {
	
	[SerializeField]
	public GameObject objToEvaluate;

	[SerializeField]
	public GameObject myObj;

	public string taging;

	public abstract bool CompareObject();
}
