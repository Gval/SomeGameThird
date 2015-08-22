using UnityEngine;
using System.Collections;

public class DistanceEvaluator : Condition  {


	public override bool CompareObject()
	{
		if(objToEvaluate != null && myObj != null){
			if ((myObj.transform.localPosition - objToEvaluate.transform.localPosition).magnitude < 25) {
				return true;
			}

		}
		
		return false;
	}

	void OnTriggerEnter (Collider collider) {
		Debug.Log ("BITCH");
		if (collider.tag == "Enemy") {
			//objToEvaluate = collider.GetComponent<GameObject>();
		}
	}
}
