using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobController : MonoBehaviour {
	private CharacterController controller;
	private Commander commander;

	private List<SoldierPawn> colleagues = new List<SoldierPawn> ();

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {
		SoldierPawn colleague;

		if (commander != null) {
			if (isRight (commander.transform)) {
				MoveToTheRight(commander.transform);
			} else {
				MoveToTheLeft(commander.transform);
			}
		} else if (colleague = hasLinedColleague ()) {
			if (isRight(colleague.transform)) {
				MoveToTheRight(commander.transform);
			} else {
				MoveToTheLeft(commander.transform);
			}
		}
	}

	public void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			commander = collider.GetComponent<Commander>();
		}
	}

	public bool isRight(Transform transform) {
		Vector3 relativePoint = transform.InverseTransformPoint(transform.position); 
		if (relativePoint.x < 0.0) { 
			return false; 
		}
		else if (relativePoint.x > 0.0) {
			return true;
		}
		else {
			return false;
		}
	}

	public SoldierPawn hasLinedColleague() {
		float closest;
		SoldierPawn closestColleague = null;

		if (colleagues.Count <= 0) {
			return null;
		}
		closest = Vector3.Distance (transform.position, colleagues [0].transform.position);
		foreach (SoldierPawn colleague in colleagues) {
			if (colleague.isLined && Vector3.Distance(transform.position, colleague.transform.position) < closest) {
				closestColleague = colleague;
				closest = Vector3.Distance(transform.position, colleague.transform.position);
			}
		}
		return closestColleague;
	}

	public void MoveToTheRight(Transform target) {
		Vector3.MoveTowards (transform.position + transform.right * 10, target.transform.position, 1);
	}

	public void MoveToTheLeft(Transform target) {
		Vector3.MoveTowards (transform.position + (-transform.right) * 10, target.transform.position, 1);
	}
}
