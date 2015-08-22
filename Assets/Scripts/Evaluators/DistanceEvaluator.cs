using UnityEngine;
using System.Collections;

public class DistanceEvaluator : Condition  {


	public override bool CompareObject()
	{
		if ((myObj.transform.localPosition - (objToEvaluate).transform.localPosition).magnitude < 25) {
			return true;
		}

		return false;
	}
}
